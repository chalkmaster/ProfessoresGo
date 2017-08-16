using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    [Serializable]
    public class gState
    {
        public int found;
        public long elapsedTime;
        public string read;
    }

    public static class WorkflowHelper
    {
        public static GameObject Camera { get; set; }
        public static gState State;
        public static GameObject pPistas;
        internal static GameObject txtQtd;
        internal static GameObject sombra;

        public static List<string> Read { get; set; }
        public static bool ShowCamera { get; set; }
        public static GameObject CamButtons { get; set; }
        public static DateTime lastTimeUpdate { get; set; }
        public static GameObject Timer { get; internal set; }
        public static GameObject txtPistas { get; internal set; }

        public static void Initialize()
        {
            Read = Read ?? new List<string>();
            State = State ?? new gState
            {
                found = 0,
                read = string.Empty,
                elapsedTime = 0,
            };
        }

        internal static void UpdateTime()
        {
            var now = DateTime.Now;
            if (now.Subtract(lastTimeUpdate).TotalSeconds > 1)
            {
                Timer.GetComponent<Text>().text = new DateTime(0).AddSeconds(State.elapsedTime++).ToString("HH:mm:ss");
                lastTimeUpdate = now;
            }
        }

        public static void Save()
        {
            State.read = string.Join(";", Read.ToArray());
            var json = JsonUtility.ToJson(State, true);
            File.WriteAllText(Application.persistentDataPath + "/state.json", json);
        }

        public static void Load()
        {
            if (!File.Exists(Application.persistentDataPath + "/state.json"))
                return;

            var json = File.ReadAllText(Application.persistentDataPath + "/state.json");
            State = JsonUtility.FromJson<gState>(json);
            Read = State.read.Split(';').ToList();
            ComputeFound();
        }

        public static void ProcessGame(string found)
        {
            var pista = string.Empty;
            if (State.found < 5)
            {
                #region case
                switch (found)
                {
                    case "10":
                        pista = "Muito Bem!\n\nSua próxima pista é:\n\"É conhecido como pai da computação.\"";
                        break;
                    case "20":
                        if (!Read.Contains("10"))
                            return;
                        pista = "Sua próxima pista é: \n\"Existem 2 caminhos a serem seguidos agora, aqueles que codificam e aqueles que analisam...\"";
                        break;
                    case "31":
                        if (!Read.Contains("20"))
                            return;
                        pista = "Sua proxima pista é: \n\"The North Remembers\"";
                        break;
                    case "32":
                        if (!Read.Contains("20"))
                            return;
                        break;
                    case "41":
                        if (!Read.Contains("31"))
                            return;

                        pista = "Ótimo!\n\nProcure pelas expressões e você encontra os tokens...\n\n";

                        if (!Read.Contains("c"))
                            pista += "\n- \"Todo mundo sabe o que é uma fita k7?\"";
                        if (!Read.Contains("f"))
                            pista += "\n- \"Moleza\"";
                        if (!Read.Contains("t"))
                            pista += "\n- \"Não existe receita de bolo\"";

                        if (Read.Contains("32"))
                        {
                            if (!Read.Contains("ip"))
                                pista += "\n- \"Mamão com açucar\"";
                            if (!Read.Contains("v"))
                                pista += "\n- \"Fácil demais meu jovem\"";
                            if (!Read.Contains("g"))
                                pista += "\n- \"Muito Fácil\"";
                        }

                        break;
                    case "42":
                        if (!Read.Contains("32"))
                            return;

                        pista = "Ótimo!\n\nProcure pelas expressões e você encontra os tokens...\n\n";

                        if (!Read.Contains("ip"))
                            pista += "\n- \"Mamão com açucar\"";
                        if (!Read.Contains("v"))
                            pista += "\n- \"Fácil demais meu jovem\"";
                        if (!Read.Contains("g"))
                            pista += "\n- \"Muito Fácil\"";

                        if (Read.Contains("31"))
                        {
                            if (!Read.Contains("c"))
                                pista += "\n- \"Todo mundo sabe o que é uma fita k7?\"";
                            if (!Read.Contains("f"))
                                pista += "\n- \"Moleza\"";
                            if (!Read.Contains("t"))
                                pista += "\n- \"Não existe receita de bolo\"";
                        }

                        break;
                    case "c":
                    case "f":
                    case "t":
                        if (!Read.Contains("41"))
                            return;
                        pista = "Muito bom! Para terminar encontre todos os outros que a verdade sera revelada...\n\n";

                        if (!Read.Contains("c"))
                            pista += "\n- \"Todo mundo sabe o que é uma fita k7?\"";
                        if (!Read.Contains("f"))
                            pista += "\n- \"Moleza\"";
                        if (!Read.Contains("t"))
                            pista += "\n- \"Não existe receita de bolo\"";

                        if (Read.Contains("32"))
                        {
                            if (!Read.Contains("ip"))
                                pista += "\n- \"Mamão com açucar\"";
                            if (!Read.Contains("v"))
                                pista += "\n- \"Fácil demais meu jovem\"";
                            if (!Read.Contains("g"))
                                pista += "\n- \"Muito Fácil\"";
                        }

                        break;
                    case "g":
                    case "v":
                    case "ip":
                        if (!Read.Contains("42"))
                            return;

                        pista = "Ótimo!\n\nProcure pelas expressões e você encontra os tokens...\n\n";

                        if (!Read.Contains("ip"))
                            pista += "\n- \"Mamão com açucar\"";
                        if (!Read.Contains("v"))
                            pista += "\n- \"Fácil demais meu jovem\"";
                        if (!Read.Contains("g"))
                            pista += "\n- \"Muito Fácil\"";

                        if (Read.Contains("31"))
                        {
                            if (!Read.Contains("c"))
                                pista += "\n- \"Todo mundo sabe o que é uma fita k7?\"";
                            if (!Read.Contains("f"))
                                pista += "\n- \"Moleza\"";
                            if (!Read.Contains("t"))
                                pista += "\n- \"Não existe receita de bolo\"";
                        }
                        break;
                    case "ic":
                        if (!Read.Contains("c") || !Read.Contains("f") || !Read.Contains("t")
                            || !Read.Contains("g") || !Read.Contains("v") || !Read.Contains("ip"))
                            return;
                        break;
                    default:
                        Debug.Log("Geeeennnte");
                        break;
                }
                #endregion
            }
            else
            {
                if (found != "10" && found != "32" && found != "ic")
                    pista = "VOCÊ ESTÁ QUASE LÁ:\n\n[MODO COORDENADOR]\n\n\"Estuda que passa, super tranquilo....\"\n\n\"O sehor ja viu o calendario ?\"";
                else if (found == "10")
                    pista = "[MODO COORDENADOR]\n\n\"Tem relação com análise.\"";
                else if (found == "32")
                    pista = "[MODO COORDENADOR]\n\n\"Nota, hum.. Zero!! Eu não estava na sala.\"\n\n\"Como você faz para achar o coordenador?\"";
                else if (found == "ic")
                {
                    pista = "PARABÉNS!\n\nNão há mais pistas. Mostre esta tela para os organizadores!";
                    sombra.SetActive(false);
                }
            }

            if (!Read.Contains(found))
                Read.Add(found);
            txtPistas.GetComponent<Text>().text = pista;
            pPistas.SetActive(true);
            ComputeFound();
        }

        public static void ComputeFound()
        {
            State.found = 0;
            if (Read.Contains("c"))
                State.found++;
            if (Read.Contains("f"))
                State.found++;
            if (Read.Contains("t"))
                State.found++;
            if (Read.Contains("g"))
                State.found++;
            if (Read.Contains("v"))
                State.found++;
            if (Read.Contains("ip"))
                State.found++;
            if (Read.Contains("ic"))
            {
                txtPistas.GetComponent<Text>().text = "PARABÉNS!\n\nNão há mais pistas. Mostre esta tela para os organizadores!";
                sombra.SetActive(false);
            }

            txtQtd.GetComponent<Text>().text = "Encontrados: " + State.found + " de 6";
        }
    }
}
