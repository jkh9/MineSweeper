using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Buscaminas
{
    public partial class PantallaBuscaminas : Form
    {
        Buscaminas buscaminas;
        PantallaPersonalizar personalizar;

        public PantallaBuscaminas()
        {
            buscaminas = new Buscaminas();
            personalizar = new PantallaPersonalizar();
            ConfigurarFormulario();
        }

        public void ConfigurarFormulario()
        {
            //Limpiar los controles actuales
            Controls.Clear();

            //Iniciamos de nuevo los basicos
            InitializeComponent();
            
            //Asignar ancho y alto correspondiente
            this.Width = 30 + (buscaminas.Width * 25);
            this.Height = 100 + (buscaminas.Height * 25) + 10;

            //Creamos los botones
            CrearBotones();

            //Reiniciamos el juego
            Reinicio();
        }

        //Crear buttons en un array para recorrerlo
        public void CrearBotones()
        {
            //Crear minas
            for (int row = 0; row < buscaminas.Height; row++)
            {
                for (int column = 0; column < buscaminas.Width; column++)
                {
                    Label boton = new Label();
                    boton.Location = new Point(15 + (column * 25), 95 + (row * 25));
                    boton.Name = row + " " + column;
                    boton.Size = new Size(25, 25);
                    boton.TabIndex = 0;
                    boton.BackColor = Color.White;
                    boton.BorderStyle = BorderStyle.FixedSingle;
                    boton.TextAlign = ContentAlignment.MiddleCenter;
                    boton.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
                    boton.MouseClick += new MouseEventHandler(button_MouseClick);
                    boton.MouseDown += new MouseEventHandler(lblBombs_MouseDown);
                    boton.MouseUp += new MouseEventHandler(lblBombs_MouseUp);
                    buscaminas.Buttons[row, column] = new BotonBuscaminas(boton);
                    this.Controls.Add(boton);
                }
            }

            //Posicion boton bombas
            lblBombs.Location = new Point(15, 40 + 2);

            //Posicion boton reset e imagen
            btnReset.Location = new Point((this.Width / 2) - (btnReset.Width / 2), 40);
            btnReset.Image = buscaminas.Images["CaritaFeliz"];

            //Posicion boton tiempo
            lblTime.Location = new Point(this.Width - lblTime.Width - 15, 40 + 2);

            //Posicion boton Exit
            btnExit.Location = new Point(this.Width - btnExit.Width, 0);

        }

        //Limpiar botones 
        public void Reinicio()
        {
            buscaminas.ReiniciarJuego();

            //Reiniciar texto de bombas y el tiempo
            lblBombs.Text = (Convert.ToInt32(buscaminas.Bombs).ToString("000") + "");
            lblTime.Text = "000";

            //Imagen del boton reset
            btnReset.Image = buscaminas.Images["CaritaFeliz"];
        }

        //click en boton reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            tmrTiempo.Stop();
            Reinicio();
        }

        //click del raton
        private void button_MouseClick(object sender, MouseEventArgs e)
        {
            //Buscamos la posicion en el array del boton pulsado
            Label actualButton = ((Label)sender);
            buscaminas.GetButtonPosition(actualButton.Name, out int bRow, out int bColumn);

            //Comprobamos que el juego no haya terminado
            if (!buscaminas.Finish)
            {
                //Si se ha pulsado el boton derecho
                if (e.Button == MouseButtons.Right)
                {
                    if (actualButton.BackColor != Color.Gray)
                    {
                        if (actualButton.Image == null && Convert.ToInt32(lblBombs.Text) > 0)
                        {
                            actualButton.Image = buscaminas.Images["Bandera"];
                            lblBombs.Text = "" + (Convert.ToInt32(lblBombs.Text) - 1).ToString("000");
                        }
                        else if (actualButton.Image == buscaminas.Images["Bandera"])
                        {
                            actualButton.Image = buscaminas.Images["Interrogacion"];
                            lblBombs.Text = "" + (Convert.ToInt32(lblBombs.Text) + 1).ToString("000");
                        }
                        else if (actualButton.Image == buscaminas.Images["Interrogacion"])
                        {
                            actualButton.Image = null;
                        }
                    }
                }
                //Si se ha pulsado el boton izquierdo
                else if (e.Button == MouseButtons.Left && actualButton.Image != buscaminas.Images["Bandera"])
                {
                    //Poner las bombas en el primer click
                    if (buscaminas.FirstClick)
                    {
                        buscaminas.PonerBombas(actualButton.Name);
                        buscaminas.FirstClick = false;
                        tmrTiempo.Start();
                    }

                    //Evento de clickar en una casilla

                    //Si el boton contiene una bomba
                    if (buscaminas.Buttons[bRow, bColumn].Bomba)
                    {
                        buscaminas.Finish = true;
                        Finish();
                    }
                    else if(buscaminas.Buttons[bRow,bColumn].Boton.Text != "")
                    {
                        if (buscaminas.LimpiarCasillas(bRow, bColumn))
                        {
                            buscaminas.Finish = true;
                            Finish();
                        }
                    }
                    //NoPerder
                    else
                    {
                        buscaminas.ComprobarCasillas(bRow, bColumn);
                    }

                    if (buscaminas.BotonesRestantes() == buscaminas.Bombs)
                    {
                        tmrTiempo.Stop();
                        buscaminas.Finish = true;
                        btnReset.Image = buscaminas.Images["CaritaGanar"];
                        MessageBox.Show("Has ganado broder!!");
                    }
                }
            }
        }

        //timer para el tiempo
        private void tmrTiempo_Tick(object sender, EventArgs e)
        {
            lblTime.Text = ""+(Convert.ToInt32(lblTime.Text) + 1).ToString("000");
        }

        //click boton de salir
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //funciones para animar la cara del boton de reset
        private void lblBombs_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(buscaminas.Finish))
            {
                btnReset.Image = buscaminas.Images["CaritaSorprendida"];
            }
        }

        private void lblBombs_MouseUp(object sender, MouseEventArgs e)
        {
            if (!(buscaminas.Finish))
            {
                btnReset.Image = buscaminas.Images["CaritaFeliz"];
            }
        }

        //Botones para cambiar el nivel de dificultad
        private void nivelFácilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscaminas.ConfiguracionJuego(8,8, 10);
            ConfigurarFormulario();
        }

        private void intermedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscaminas.ConfiguracionJuego(16,16, 40);
            ConfigurarFormulario();
        }

        private void expertoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscaminas.ConfiguracionJuego(30,16, 99);
            ConfigurarFormulario();
        }

        //Dll para poder mover el formulario conel stripmenu
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Finish()
        {
            btnReset.Image = buscaminas.Images["CaritaMuerta"];
            tmrTiempo.Stop();
            buscaminas.MostrarBombas();
            buscaminas.MostrarBanderasEquivocadas();
        }

        private void personalizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int width = buscaminas.Width;
            int height = buscaminas.Height;
            int bombs = buscaminas.Bombs;

            personalizar.ShowDialog();
            personalizar.GetData(ref width,ref height, ref bombs);
            buscaminas.ConfiguracionJuego(width, height, bombs);
            ConfigurarFormulario();
        }
    }
}
