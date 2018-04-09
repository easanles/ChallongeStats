using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ChallongeStats {
    public partial class Principal : Form {
        private readonly string JUG1_NAME_FILENAME = "p1_name.txt";
        private readonly string JUG2_NAME_FILENAME = "p2_name.txt";

        private readonly string JUG1_GAME_COUNT_FILENAME = "p1_games.txt";
        private readonly string JUG1_WIN_COUNT_FILENAME = "p1_wins.txt";
        private readonly string JUG1_LOSS_COUNT_FILENAME = "p1_loses.txt";
        private readonly string JUG1_WIN_RATIO_FILENAME = "p1_winrate.txt";
        private readonly string JUG1_LOSERS_BY_FILENAME = "p1_losersby.txt";
        private readonly string JUG2_GAME_COUNT_FILENAME = "p2_games.txt";
        private readonly string JUG2_WIN_COUNT_FILENAME = "p2_wins.txt";
        private readonly string JUG2_LOSS_COUNT_FILENAME = "p2_loses.txt";
        private readonly string JUG2_WIN_RATIO_FILENAME = "p2_winrate.txt";
        private readonly string JUG2_LOSERS_BY_FILENAME = "p2_losersby.txt";

        private readonly string PLAYER_DATA_FILENAME = "playerdata.txt";
        private readonly string JUG1_PLAYER_DATA = "p1_text.txt";
        private readonly string JUG2_PLAYER_DATA = "p2_text.txt";

        //config
        private readonly string CONFIG_FILE_NAME = "config.ini";
        private readonly string GENERATED_IMGS_NUM_VARNAME = "GENERATED_IMGS_NUM";
        private readonly string API_KEY_VARNAME = "API_KEY";
        private readonly string LAST_CHALLONGE_ID_VARNAME = "LAST_CHALLONGE_ID";
        private readonly string LAST_OUTPUT_DIR_VARNAME = "LAST_OUTPUT_DIR";
        private readonly string READ_P1_NAME_FROM_VARNAME = "READ_P1_NAME_FROM_DIR";
        private readonly string READ_P2_NAME_FROM_VARNAME = "READ_P2_NAME_FROM_DIR";
        private int generatedImgsNum = 4;
        private string readP1NameFrom = "";
        private string readP2NameFrom = "";

        public Principal() {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e) {
            try {
                string[] config = File.ReadAllLines(CONFIG_FILE_NAME);
                foreach (string line in config) {
                    string[] parts = line.Split('=');
                    if (parts[0].ToUpper().Trim().Equals(API_KEY_VARNAME))
                        txtApiKey.Text = parts[1].Trim();
                    if (parts[0].ToUpper().Trim().Equals(LAST_CHALLONGE_ID_VARNAME))
                        txtId.Text = parts[1].Trim();
                    if (parts[0].ToUpper().Trim().Equals(LAST_OUTPUT_DIR_VARNAME))
                        txtGuardarEn.Text = parts[1].Trim();
                    if (parts[0].ToUpper().Trim().Equals(generatedImgsNum))
                        int.TryParse(parts[1].Trim(), out generatedImgsNum);
                    if (parts[0].ToUpper().Trim().Equals(READ_P1_NAME_FROM_VARNAME))
                        readP1NameFrom = parts[1].Trim();
                    if (parts[0].ToUpper().Trim().Equals(READ_P2_NAME_FROM_VARNAME))
                        readP2NameFrom = parts[1].Trim();
                }
            } catch (FileNotFoundException) {
                File.WriteAllText(CONFIG_FILE_NAME,
                    API_KEY_VARNAME + "=\n" +
                    LAST_CHALLONGE_ID_VARNAME + "=\n" +
                    LAST_OUTPUT_DIR_VARNAME + "=\n" +
                    GENERATED_IMGS_NUM_VARNAME + "=" + generatedImgsNum + "\n" +
                    READ_P1_NAME_FROM_VARNAME + "=\n" + 
                    READ_P2_NAME_FROM_VARNAME + "=\n");
                lblEstado.Text = "Generado fichero " + CONFIG_FILE_NAME + " vacío";
            } catch (Exception ex) {
                lblEstado.Text = "Error al leer archivo de configuración: " + ex.Message;
                MessageBox.Show(ex.Message, "Error al leer archivo de configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardarEn_Click(object sender, EventArgs e) {
            folderBrowserDialog.ShowDialog();
            txtGuardarEn.Text = folderBrowserDialog.SelectedPath;
        }

        private void BtnGenerar_Click(object sender, EventArgs e) {
            Start();
        }

        private void BtnSwapNames_Click(object sender, EventArgs e) {
            string aux = txtJug1.Text;
            txtJug1.Text = txtJug2.Text;
            txtJug2.Text = aux;
        }


        bool alreadyFocused1 = false, alreadyFocused2 = false;

        private void txtJug1_Enter(object sender, EventArgs e) {
            if (MouseButtons == MouseButtons.None) {
                txtJug1.SelectAll();
                alreadyFocused1 = true;
            }
        }

        private void txtJug1_Leave(object sender, EventArgs e) {
            alreadyFocused1 = false;
        }

        private void txtJug1_MouseUp(object sender, MouseEventArgs e) {
            if (!alreadyFocused1 && txtJug1.SelectionLength == 0) {
                alreadyFocused1 = true;
                txtJug1.SelectAll();
            }
        }

        private void txtJug2_Enter(object sender, EventArgs e) {
            if (MouseButtons == MouseButtons.None) {
                txtJug2.SelectAll();
                alreadyFocused2 = true;
            }
        }

        private void txtJug2_Leave(object sender, EventArgs e) {
            alreadyFocused2 = false;
        }


        private void txtJug2_MouseUp(object sender, MouseEventArgs e) {
            if (!alreadyFocused2 && txtJug2.SelectionLength == 0) {
                alreadyFocused2 = true;
                txtJug2.SelectAll();
            }
        }

        private void txtJug1_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Return) {
                Start();
            }
        }

        private void txtJug2_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Return) {
                Start();
            }
        }

        private void Start() {
            SaveConfigFile();
            GenerateTexts();
            GeneratePlayerData();
        }

        private void SaveConfigFile() {
            try {
                File.WriteAllText(CONFIG_FILE_NAME,
                            API_KEY_VARNAME + "=" + txtApiKey.Text.Trim() + "\n" +
                            LAST_CHALLONGE_ID_VARNAME + "=" + txtId.Text.Trim() + "\n" +
                            LAST_OUTPUT_DIR_VARNAME + "=" + txtGuardarEn.Text.Trim() + "\n" +
                            GENERATED_IMGS_NUM_VARNAME + "=" + generatedImgsNum + "\n" + 
                            READ_P1_NAME_FROM_VARNAME + "=" + readP1NameFrom + "\n" +
                            READ_P2_NAME_FROM_VARNAME + "=" + readP2NameFrom + "\n");
            } catch (Exception ex) {
                lblEstado.Text = "Error al guardar archivo de configuración: " + ex.Message;
                MessageBox.Show(ex.Message, "Error al guardar archivo de configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void GenerateTexts() {
            if (cbDoStats.Checked == false)
                return;
            if (string.IsNullOrEmpty(txtId.Text)) {
                lblEstado.Text = "El campo \"Identificador\" está vacío.";
                return;
            }
            if (string.IsNullOrEmpty(txtGuardarEn.Text)) {
                lblEstado.Text = "El campo \"Guardar en\" está vacío.";
                return;
            }
            try {
                Path.GetFullPath(txtGuardarEn.Text);
            } catch (Exception ex) {
                lblEstado.Text = "La ruta de \"Guardar en\" no es válida: " + ex.GetType().ToString();
                return;
            };

            lblEstado.Text = "Obteniendo listado de participantes.";
            long p1Id = -1, p2Id = -1;
            List<long> p1GroupIds = new List<long>(), p2GroupIds = new List<long>();
            List<Participant> participantes = new List<Participant>();
            string nombreJug1 = txtJug1.Text;
            string nombreJug2 = txtJug2.Text;

            try {
                participantes = await ChallongeService.GetListado(txtApiKey.Text, txtId.Text);
                if (participantes == null) {
                    lblEstado.Text = "No se han obtenido participantes. Revisa el id.";
                    return;
                }

                if (string.IsNullOrWhiteSpace(nombreJug1)) {
                    try {
                        nombreJug1 = File.ReadAllText(readP1NameFrom);
                    } catch { }
                }
                if (string.IsNullOrWhiteSpace(nombreJug2)) {
                    try {
                        nombreJug2 = File.ReadAllText(readP2NameFrom);
                    } catch { }
                }

                foreach (Participant p in participantes) {
                    if (p.DisplayName.ToLower().Equals(nombreJug1.Trim().ToLower())) {
                        p1Id = p.Id;
                        p1GroupIds = p.GroupIds;
                    }
                    if (p.DisplayName.ToLower().Equals(nombreJug2.Trim().ToLower())) {
                        p2Id = p.Id;
                        p2GroupIds = p.GroupIds;
                    }
                    if (p1Id != -1 && p2Id != -1) {
                        break;
                    }
                }
            } catch (Exception ex) {
                lblEstado.Text = "Error al obtener participantes: " + ex.Message;
                MessageBox.Show(ex.Message, "Error al obtener participantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblEstado.Text = "Obteniendo partidas.";
            List<Match> partidasJug1 = null;
            List<Match> partidasJug2 = null;
            try {
                if (p1Id != -1)
                    partidasJug1 = await ChallongeService.GetPartidas(txtApiKey.Text, txtId.Text, p1Id);
                if (p2Id != -1)
                    partidasJug2 = await ChallongeService.GetPartidas(txtApiKey.Text, txtId.Text, p2Id);
            } catch (Exception ex) {
                lblEstado.Text = "Error al obtener partidas: " + ex.Message;
                MessageBox.Show(ex.Message, "Error al obtener partidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblEstado.Text = "Contando puntos.";
            int countPartidasJug1 = 0, countVictoriasJug1 = 0, countDerrotasJug1 = 0;
            int countPartidasJug2 = 0, countVictoriasJug2 = 0, countDerrotasJug2 = 0;
            long? jug1UltimaVictoria = null, jug2UltimaVictoria = null;
            long? jug1PerdioContra = null, jug2PerdioContra = null;
            long? jug1UltimaPartidaGrupos = null, jug2UltimaPartidaGrupos = null;
            string jug1ResultadoMostrado = "", jug2ResultadoMostrado = "";

            try {
                if (partidasJug1 != null) {
                    foreach (Match m in partidasJug1) {
                        //Si hay fase de grupos, los ids seran diferentes, sustituirlos por el id general.
                        if (m.GroupId != null && p1GroupIds.Count > 0) {
                            m.Player1Id = participantes.Where(p => p.GroupIds.Contains(m.Player1Id.Value)).Single().Id;
                            m.Player2Id = participantes.Where(p => p.GroupIds.Contains(m.Player2Id.Value)).Single().Id;
                            if (m.WinnerId != null)
                                m.WinnerId = participantes.Where(p => p.GroupIds.Contains(m.WinnerId.Value)).Single().Id;
                            if (m.LoserId != null)
                                m.LoserId = participantes.Where(p => p.GroupIds.Contains(m.LoserId.Value)).Single().Id;
                        }

                        string[] puntos = m.ScoresCsv.Split('-');
                        if (puntos.Length == 2) {
                            int ladoIzq = int.Parse(puntos[0]);
                            int ladoDer = int.Parse(puntos[1]);
                            countPartidasJug1 += ladoIzq + ladoDer;
                            if (m.Player1Id == p1Id) {
                                countVictoriasJug1 += ladoIzq;
                                countDerrotasJug1 += ladoDer;
                            } else {
                                countVictoriasJug1 += ladoDer;
                                countDerrotasJug1 += ladoIzq;
                            }

                            if (m.GroupId != null) { //Es de fase de grupos
                                if (m.Player1Id == p1Id) {
                                    jug1UltimaPartidaGrupos = m.Player2Id;
                                    jug1ResultadoMostrado = string.Format("{0}-{1}", ladoIzq, ladoDer);
                                } else {
                                    jug1UltimaPartidaGrupos = m.Player1Id;
                                    jug1ResultadoMostrado = string.Format("{0}-{1}", ladoDer, ladoIzq);
                                }
                            } else if (m.LoserId == p1Id) {
                                jug1UltimaPartidaGrupos = null;
                                jug1PerdioContra = m.WinnerId;
                                if (m.Player1Id == p1Id) {
                                    jug1ResultadoMostrado = string.Format("{0}-{1}", ladoIzq, ladoDer);
                                } else {
                                    jug1ResultadoMostrado = string.Format("{0}-{1}", ladoDer, ladoIzq);
                                }
                            } else if (m.WinnerId == p1Id) {
                                jug1UltimaPartidaGrupos = null;
                                jug1UltimaVictoria = m.LoserId;
                                if (jug1PerdioContra == null) {
                                    if (m.Player1Id == p1Id) {
                                        jug1ResultadoMostrado = string.Format("{0}-{1}", ladoIzq, ladoDer);
                                    } else {
                                        jug1ResultadoMostrado = string.Format("{0}-{1}", ladoDer, ladoIzq);
                                    }
                                }
                            }
                        }
                    }
                }

                if (partidasJug2 != null) {
                    foreach (Match m in partidasJug2) {
                        //Si hay fase de grupos, los ids seran diferentes, sustituirlos por el id general.
                        if (m.GroupId != null && p2GroupIds.Count > 0) {
                            m.Player1Id = participantes.Where(p => p.GroupIds.Contains(m.Player1Id.Value)).Single().Id;
                            m.Player2Id = participantes.Where(p => p.GroupIds.Contains(m.Player2Id.Value)).Single().Id;
                            if (m.WinnerId != null)
                                m.WinnerId = participantes.Where(p => p.GroupIds.Contains(m.WinnerId.Value)).Single().Id;
                            if (m.LoserId != null)
                                m.LoserId = participantes.Where(p => p.GroupIds.Contains(m.LoserId.Value)).Single().Id;
                        }

                        string[] puntos = m.ScoresCsv.Split('-');
                        if (puntos.Length == 2) {
                            int ladoIzq = int.Parse(puntos[0]);
                            int ladoDer = int.Parse(puntos[1]);
                            countPartidasJug2 += ladoIzq + ladoDer;
                            if (m.Player1Id == p2Id) {
                                countVictoriasJug2 += ladoIzq;
                                countDerrotasJug2 += ladoDer;
                            } else {
                                countVictoriasJug2 += ladoDer;
                                countDerrotasJug2 += ladoIzq;
                            }

                            if (m.GroupId != null) { //Es de fase de grupos
                                if (m.Player1Id == p2Id) {
                                    jug2UltimaPartidaGrupos = m.Player2Id;
                                    jug2ResultadoMostrado = string.Format("{0}-{1}", ladoIzq, ladoDer);
                                } else {
                                    jug2UltimaPartidaGrupos = m.Player1Id;
                                    jug2ResultadoMostrado = string.Format("{0}-{1}", ladoDer, ladoIzq);
                                }
                            } else if (m.LoserId == p2Id) {
                                jug2UltimaPartidaGrupos = null;
                                jug2PerdioContra = m.WinnerId;
                                if (m.Player1Id == p2Id) {
                                    jug2ResultadoMostrado = string.Format("{0}-{1}", ladoIzq, ladoDer);
                                } else {
                                    jug2ResultadoMostrado = string.Format("{0}-{1}", ladoDer, ladoIzq);
                                }
                            } else if (m.WinnerId == p2Id) {
                                jug2UltimaPartidaGrupos = null;
                                jug2UltimaVictoria = m.LoserId;
                                if (jug2PerdioContra == null) {
                                    if (m.Player1Id == p2Id) {
                                        jug2ResultadoMostrado = string.Format("{0}-{1}", ladoIzq, ladoDer);
                                    } else {
                                        jug2ResultadoMostrado = string.Format("{0}-{1}", ladoDer, ladoIzq);
                                    }
                                }
                            }

                        }
                    }
                }
            } catch (Exception ex) {
                lblEstado.Text = "Error al parsear las puntuaciones: " + ex.Message;
                MessageBox.Show(ex.Message, "Error al parsear las puntuaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblEstado.Text = "Generando archivos de texto.";
            string ruta = txtGuardarEn.Text;
            if (string.IsNullOrEmpty(ruta) || (ruta.Last() != '\\')) {
                ruta = ruta + '\\';
            }
            try {
                //File.WriteAllText(ruta + JUG1_NAME_FILENAME, (p1Id != -1) ? txtJug1.Text : "");
                //File.WriteAllText(ruta + JUG2_NAME_FILENAME, (p2Id != -1) ? txtJug2.Text : "");
                File.WriteAllText(ruta + JUG1_NAME_FILENAME, nombreJug1.Trim());
                File.WriteAllText(ruta + JUG2_NAME_FILENAME, nombreJug2.Trim());

                File.WriteAllText(ruta + JUG1_GAME_COUNT_FILENAME, (partidasJug1 != null) ? countPartidasJug1.ToString() : "");
                File.WriteAllText(ruta + JUG1_WIN_COUNT_FILENAME, (partidasJug1 != null) ? countVictoriasJug1.ToString() : "");
                File.WriteAllText(ruta + JUG1_LOSS_COUNT_FILENAME, (partidasJug1 != null) ? countDerrotasJug1.ToString() : "");
                if (countPartidasJug1 > 0)
                    File.WriteAllText(ruta + JUG1_WIN_RATIO_FILENAME, (partidasJug1 != null) ? string.Format("{0:F0}%", decimal.Divide(countVictoriasJug1, countPartidasJug1) * 100) : "");
                else
                    File.WriteAllText(ruta + JUG1_WIN_RATIO_FILENAME, (partidasJug1 != null) ? "--" : "");
                File.WriteAllText(ruta + JUG2_GAME_COUNT_FILENAME, (partidasJug2 != null) ? countPartidasJug2.ToString() : "");
                File.WriteAllText(ruta + JUG2_WIN_COUNT_FILENAME, (partidasJug2 != null) ? countVictoriasJug2.ToString() : "");
                File.WriteAllText(ruta + JUG2_LOSS_COUNT_FILENAME, (partidasJug2 != null) ? countDerrotasJug2.ToString() : "");
                if (countPartidasJug2 > 0)
                    File.WriteAllText(ruta + JUG2_WIN_RATIO_FILENAME, (partidasJug2 != null) ? string.Format("{0:F0}%", decimal.Divide(countVictoriasJug2, countPartidasJug2) * 100) : "");
                else
                    File.WriteAllText(ruta + JUG2_WIN_RATIO_FILENAME, (partidasJug2 != null) ? "--" : "");

                if (jug1UltimaPartidaGrupos != null) {
                    string jug1NombreRival = participantes.Find(p => p.Id == jug1UltimaPartidaGrupos).DisplayName;
                    File.WriteAllText(ruta + JUG1_LOSERS_BY_FILENAME, string.Format("Último enfrentamiento VS:  {0}  ( {1} )", jug1NombreRival, jug1ResultadoMostrado));
                } else if (jug1PerdioContra != null) {
                    string jug1NombreRival = participantes.Find(p => p.Id == jug1PerdioContra).DisplayName;
                    File.WriteAllText(ruta + JUG1_LOSERS_BY_FILENAME, string.Format("En Losers Bracket por:  {0}  ( {1} )", jug1NombreRival, jug1ResultadoMostrado));
                } else if (jug1UltimaVictoria != null) {
                    string jug1NombreRival = participantes.Find(p => p.Id == jug1UltimaVictoria).DisplayName;
                    File.WriteAllText(ruta + JUG1_LOSERS_BY_FILENAME, string.Format("Última victoria VS:  {0}  ( {1} )", jug1NombreRival, jug1ResultadoMostrado));
                } else {
                    File.WriteAllText(ruta + JUG1_LOSERS_BY_FILENAME, "Primera participación");
                }

                if (jug2UltimaPartidaGrupos != null) {
                    string jug2NombreRival = participantes.Find(p => p.Id == jug2UltimaPartidaGrupos).DisplayName;
                    File.WriteAllText(ruta + JUG2_LOSERS_BY_FILENAME, string.Format("Último enfrentamiento VS:  {0}  ( {1} )", jug2NombreRival, jug2ResultadoMostrado));
                } else if (jug2PerdioContra != null) {
                    string jug2NombreRival = participantes.Find(p => p.Id == jug2PerdioContra).DisplayName;
                    File.WriteAllText(ruta + JUG2_LOSERS_BY_FILENAME, string.Format("En Losers Bracket por:  {0}  ( {1} )", jug2NombreRival, jug2ResultadoMostrado));
                } else if (jug2UltimaVictoria != null) {
                    string jug2NombreRival = participantes.Find(p => p.Id == jug2UltimaVictoria).DisplayName;
                    File.WriteAllText(ruta + JUG2_LOSERS_BY_FILENAME, string.Format("Última victoria VS:  {0}  ( {1} )", jug2NombreRival, jug2ResultadoMostrado));
                } else {
                    File.WriteAllText(ruta + JUG2_LOSERS_BY_FILENAME, "Primera participación");
                }
            } catch (Exception ex) {
                lblEstado.Text = "Error al guardar textos: " + ex.Message;
                MessageBox.Show(ex.Message, "Error al guardar textos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblEstado.Text = "Hecho.";
        }

        private void GeneratePlayerData() {
            if (cbDoPlayerData.Checked == false)
                return;
            string p1name = txtJug1.Text.ToLower().Trim();
            string p2name = txtJug2.Text.ToLower().Trim();
            bool lookingAtP1 = false;
            bool lookingAtP2 = false;
            bool p1Found = false;
            bool p2Found = false;
            string p1text = "";
            string p2text = "";
            List<string> p1images = new List<string>();
            List<string> p2images = new List<string>();

            if (string.IsNullOrWhiteSpace(p1name)) {
                try {
                    p1name = File.ReadAllText(readP1NameFrom).ToLower().Trim();
                } catch { }
            }
            if (string.IsNullOrWhiteSpace(p2name)) {
                try {
                    p2name = File.ReadAllText(readP2NameFrom).ToLower().Trim();
                } catch { }
            }

            try {
                //lblEstado.Text = "Abriendo fichero " + PLAYER_DATA_FILENAME;
                string[] lines = File.ReadAllLines(PLAYER_DATA_FILENAME);

                //lblEstado.Text = "Leyendo información";
                foreach (string line in lines) {
                    if (line[0] == ';') //Comentario
                        continue;
                    else if (line[0] == '@') { //Nombre jugador
                        lookingAtP1 = false;
                        lookingAtP2 = false;
                        string currentName = line.Substring(1).ToLower().Trim();
                        if (!currentName.Equals(p1name) && !currentName.Equals(p2name)) {
                            continue;
                        } else {
                            if (currentName.Equals(p1name)) {
                                lookingAtP1 = true;
                                p1Found = true;
                            }
                            if (currentName.Equals(p2name)) {
                                lookingAtP2 = true;
                                p2Found = true;
                            }
                        }
                    } else if (line[0] == '|') { //Imagen
                        if (lookingAtP1)
                            p1images.Add(line.Substring(1).Trim());
                        if (lookingAtP2)
                            p2images.Add(line.Substring(1).Trim());
                    } else { //Texto
                        if (lookingAtP1) {
                            p1text += line + '\n';
                        }
                        if (lookingAtP2) {
                            p2text += line + '\n';
                        }
                    }
                }

                //lblEstado.Text = "Generando textos de información de los jugadores";
                string path = txtGuardarEn.Text;
                if (string.IsNullOrEmpty(path) || (path.Last() != '\\')) {
                    path = path + '\\';
                }
                File.WriteAllText(path + JUG1_PLAYER_DATA, p1text.Trim());
                File.WriteAllText(path + JUG2_PLAYER_DATA, p2text.Trim());

                //lblEstado.Text = "Generando imagenes de los jugadores";
                for (int i = 0; i < generatedImgsNum; i++) {
                    string savePath = path + "p1_img" + (i + 1) + ".png";
                    if (i >= p1images.Count) {
                        EmptyImage(savePath);
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(p1images[i])) {
                        EmptyImage(savePath);
                        continue;
                    }
                    try {
                        string rutaimg = "img/" + p1images[i];
                        Byte[] bytes = File.ReadAllBytes(rutaimg + ".png");
                        File.WriteAllBytes(savePath, bytes);
                    } catch (FileNotFoundException) {
                        EmptyImage(savePath);
                    }
                }
                for (int i = 0; i < generatedImgsNum; i++) {
                    string savePath = path + "p2_img" + (i + 1) + ".png";
                    if (i >= p2images.Count) {
                        EmptyImage(savePath);
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(p2images[i])) {
                        EmptyImage(savePath);
                        continue;
                    }
                    try {
                        string rutaimg = "img/" + p2images[i];
                        Byte[] bytes = File.ReadAllBytes(rutaimg + ".png");
                        File.WriteAllBytes(path + "p2_img" + (i + 1) + ".png", bytes);
                    } catch (FileNotFoundException) {
                        EmptyImage(savePath);
                    }
                }
                for (int i = 0; i < generatedImgsNum; i++) { //Vaciar imagenes resultado si no se ha encontrado el jugador
                    if (p1Found == false)
                        EmptyImage(path + "p1_img" + (i + 1) + ".png");
                    if (p2Found == false)
                        EmptyImage(path + "p2_img" + (i + 1) + ".png");
                }

                //lblEstado.Text = "Hecho.";
            } catch (FileNotFoundException) {
                File.WriteAllText(PLAYER_DATA_FILENAME, @";FORMATO DE ESTE ARCHIVO
;
;Comenzar una linea con @: indicar nombre de jugador, no sensible a minusculas/mayusculas
;Comenzar una linea con |: indicar una imagen del jugador dentro de la ruta ./img/  La primera imagen se guarda en p*_img1.png, la segunda en p*_img2.png, ...
;Comenzar una linea con ;: indicar un comentario, se ignora la linea
;Cualquier otra linea debajo de un nombre de jugador: el texto asociado al jugador. Se guardará en p*_text.txt
;
");
                //lblEstado.Text = "Generado fichero " + PLAYER_DATA_FILENAME + " vacío";
            } catch (Exception ex) {
                lblEstado.Text = "Error al obtener datos del jugador: " + ex.Message;
                MessageBox.Show(ex.Message, "Error al obtener datos del jugador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EmptyImage(string rutaimg) {
            FileStream stream = File.OpenWrite(rutaimg);
            Bitmap bmp = new Bitmap(1, 1);
            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Close();
        }
    }
}
