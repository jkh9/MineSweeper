using System;
using System.Collections.Generic;
using System.Drawing;

namespace Buscaminas
{
    class Buscaminas
    {
        public BotonBuscaminas[,] Buttons { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Bombs { get; set; }
        public bool FirstClick { get; set; }
        public bool Finish { get; set; }
        public Dictionary<string, Image> Images { get; }

        public Buscaminas()
        {
            Images = new Dictionary<string, Image>(5);
            CargarImagenes();
            ConfiguracionJuego(8, 8, 10);
        }

        public void ConfiguracionJuego(int newBWidth, int newBHeight, int newBombs)
        {
            this.Width = newBWidth;
            this.Height = newBHeight;
            this.Bombs = newBombs;
            this.Buttons = new BotonBuscaminas[Height, Width];
        }

        public void CargarImagenes()
        {
            Images.Add("CaritaFeliz", Image.FromFile("imgs//CaritaFeliz.png"));
            Images.Add("CaritaSorprendida", Image.FromFile("imgs//CaritaSorprendida.png"));
            Images.Add("CaritaMuerta", Image.FromFile("imgs//CaritaMuerta.png"));
            Images.Add("CaritaGanar", Image.FromFile("imgs//CaritaGanar.png"));
            Images.Add("Bomba", Image.FromFile("imgs//mina.png"));
            Images.Add("BombaEquivocada", Image.FromFile("imgs//minaEquivocada.png"));
            Images.Add("Bandera", Image.FromFile("imgs//marxismo.png"));
            Images.Add("Interrogacion", Image.FromFile("imgs//interrogacion.png"));
        }

        public void ReiniciarJuego()
        {
            //Reiniciar bombas y numeros
            for (int row = 0; row < Height; row++)
            {
                for (int column = 0; column < Width; column++)
                {
                    Buttons[row, column].Bomba = false;
                    Buttons[row, column].Number = 0;
                    Buttons[row, column].Boton.Text = "";
                    Buttons[row, column].Boton.Enabled = true;
                    Buttons[row, column].Boton.Image = null;
                    Buttons[row, column].Boton.BackColor = Color.White;
                }
            }

            //Variable de primer click
            FirstClick = true;

            //Variable de juego
            Finish = false;
        }

        public void PonerBombas(string name)
        {
            GetButtonPosition(name, out int cRow, out int cColumn);

            //Poner Bombas en su sitio aleatorio
            Random r = new Random();

            int bRow, bColumn;
            for (int i = 0; i < Bombs; i++)
            {
                do
                {
                    bRow = r.Next(0, Height);
                    bColumn = r.Next(0, Width);
                }
                while (Buttons[bRow, bColumn].Bomba ||
                    bRow == cRow && bColumn == cColumn ||
                    bRow == cRow - 1 && bColumn == cColumn + 1 ||
                    bRow == cRow - 1 && bColumn == cColumn ||
                    bRow == cRow - 1 && bColumn == cColumn - 1 ||
                    bRow == cRow && bColumn == cColumn - 1 ||
                    bRow == cRow && bColumn == cColumn + 1 ||
                    bRow == cRow + 1 && bColumn == cColumn + 1 ||
                    bRow == cRow + 1 && bColumn == cColumn ||
                    bRow == cRow + 1 && bColumn == cColumn - 1);
                Buttons[bRow, bColumn].Bomba = true;
            }

            AsignarNumeros();
        }

        private void AsignarNumeros()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int column = 0; column < Width; column++)
                {
                    if (Buttons[row, column].Bomba == true)
                    {
                        //Comprobamos que este dentro del array y sumamos uno alrededor
                        if (column - 1 >= 0 && row - 1 >= 0 && !(Buttons[row - 1, column - 1].Bomba))
                            Buttons[row - 1, column - 1].Number += 1;
                        if (column - 1 >= 0 && !(Buttons[row, column - 1].Bomba))
                            Buttons[row, column - 1].Number += 1;
                        if (column - 1 >= 0 && row + 1 < Height && !(Buttons[row + 1, column - 1].Bomba))
                            Buttons[row + 1, column - 1].Number += 1;
                        if (row + 1 < Height && !(Buttons[row + 1, column].Bomba))
                            Buttons[row + 1, column].Number += 1;
                        if (column + 1 < Width && row + 1 < Height && !(Buttons[row + 1, column + 1].Bomba))
                            Buttons[row + 1, column + 1].Number += 1;
                        if (column + 1 < Width && !(Buttons[row, column + 1].Bomba))
                            Buttons[row, column + 1].Number += 1;
                        if (column + 1 < Width && row - 1 >= 0 && !(Buttons[row - 1, column + 1].Bomba))
                            Buttons[row - 1, column + 1].Number += 1;
                        if (row - 1 >= 0 && !(Buttons[row - 1, column].Bomba))
                            Buttons[row - 1, column].Number += 1;
                    }
                }
            }
        }

        public void ComprobarCasillas(int actualRow, int actualColumn)
        {
            //SI Se sale devuelve vacio
            if (actualRow < 0 || actualRow > Height - 1 ||
                actualColumn < 0 || actualColumn > Width - 1)
            {

            }
            //Si el color de fondo es gris, se sale
            else if (Buttons[actualRow, actualColumn].Boton.BackColor == Color.Gray)
            {

            }
            //Si la imagen de fondo es bandera o interrogacion se sale
            else if (Buttons[actualRow, actualColumn].Boton.Image == Images["Bandera"] ||
                Buttons[actualRow, actualColumn].Boton.Image == Images["Interrogacion"])
            {

            }
            //Si hay un numero se escribe el numero y para
            else if (Buttons[actualRow, actualColumn].Number != 0)
            {
                Buttons[actualRow, actualColumn].Boton.BackColor = Color.Gray;
                Buttons[actualRow, actualColumn].Boton.ForeColor = 
                    GetColor(Buttons[actualRow, actualColumn].Number);
                Buttons[actualRow, actualColumn].Boton.Text =
                    "" + Buttons[actualRow, actualColumn].Number;
            }
            //Si no hay numero pulsa el boton y busca alrededor
            else if (Buttons[actualRow, actualColumn].Number == 0)
            {
                Buttons[actualRow, actualColumn].Boton.BackColor = Color.Gray;
                ComprobarCasillas(actualRow - 1, actualColumn - 1);
                ComprobarCasillas(actualRow, actualColumn - 1);
                ComprobarCasillas(actualRow + 1, actualColumn - 1);
                ComprobarCasillas(actualRow + 1, actualColumn);
                ComprobarCasillas(actualRow + 1, actualColumn + 1);
                ComprobarCasillas(actualRow, actualColumn + 1);
                ComprobarCasillas(actualRow - 1, actualColumn + 1);
                ComprobarCasillas(actualRow - 1, actualColumn);
            }
        }

        //Funcion auxiliar para cambiar el nombre de los botones por la posicion en el array
        public void GetButtonPosition(string name, out int aRow, out int aColumn)
        {
            string[] parts = name.Split();
            aRow = Convert.ToInt32(parts[0]);
            aColumn = Convert.ToInt32(parts[1]);
        }

        public void MostrarBombas()
        {
            foreach (BotonBuscaminas item in Buttons)
            {
                if (item.Bomba && !(item.Boton.Image == Images["Bandera"]))
                {
                    item.Boton.Image = Images["Bomba"];
                }
            }
        }

        public void MostrarBanderasEquivocadas()
        {
            foreach (BotonBuscaminas item in Buttons)
            {
                if (item.Boton.Image == Images["Bandera"] && !(item.Bomba))
                {
                    item.Boton.Image = Images["BombaEquivocada"];
                }
            }
        }

        public int BotonesRestantes()
        {
            int cont = 0;
            for (int row = 0; row < Height; row++)
            {
                for (int column = 0; column < Width; column++)
                {
                    if (Buttons[row, column].Boton.BackColor != Color.Gray)
                    {
                        cont++;
                    }
                }
            }
            return cont;
        }

        public Color GetColor(int number)
        {
            switch (number)
            {
                case 1: return Color.DarkBlue;
                case 2: return Color.DarkGreen;
                case 3: return Color.DarkRed;
                case 4: return Color.DarkMagenta;
                case 5: return Color.Indigo;
                case 6: return Color.LightBlue;
                case 7: return Color.MediumSpringGreen;
                case 8: return Color.Sienna;
            }
            return Color.Black;
        }

        public bool LimpiarCasillas(int row, int column)
        {
            //Cogemos el numero de la casilla
            int botonNumber = Convert.ToInt32(Buttons[row, column].Boton.Text);

            //Contamos el numero de banderas alrededor
            int flagsNumber = 0;

            if (row - 1 >= 0 && column -1 >= 0 && 
                Buttons[row - 1, column - 1].Boton.Image == Images["Bandera"])
                flagsNumber++;
            if (column - 1 >= 0 && 
                Buttons[row, column - 1].Boton.Image == Images["Bandera"])
                flagsNumber++;
            if (row + 1 < Height && column - 1 >= 0 && 
                Buttons[row + 1, column - 1].Boton.Image == Images["Bandera"])
                flagsNumber++;
            if (row + 1 < Height&& 
                Buttons[row + 1, column].Boton.Image == Images["Bandera"])
                flagsNumber++;
            if (row - 1 >= 0 &&
                Buttons[row - 1, column].Boton.Image == Images["Bandera"])
                flagsNumber++;
            if (row - 1 >= 0 && column + 1 < Width && 
                Buttons[row - 1, column + 1].Boton.Image == Images["Bandera"])
                flagsNumber++;
            if (column + 1 < Width && 
                Buttons[row, column + 1].Boton.Image == Images["Bandera"])
                flagsNumber++;
            if (row + 1 < Height && column + 1 < Width && 
                Buttons[row + 1, column + 1].Boton.Image == Images["Bandera"])
                flagsNumber++;

            //Comprobamos que haya ese numero de veces banderas

            //Si es limpiamos alrededor
            if (flagsNumber == botonNumber)
            {
                return LimpiaCasilla(row - 1, column - 1) || LimpiaCasilla(row + 1, column + 1) ||
                    LimpiaCasilla(row, column - 1) || LimpiaCasilla(row + 1, column - 1) ||
                    LimpiaCasilla(row + 1, column) || LimpiaCasilla(row - 1, column) ||
                    LimpiaCasilla(row - 1, column + 1) || LimpiaCasilla(row, column + 1);
            }
            return false;
        }

        private bool LimpiaCasilla(int row, int column)
        {
            //SI Se sale devuelve vacio
            if (row < 0 || row > Height - 1 ||
                column < 0 || column > Width - 1)
            {
                return false;
            }
            //Si el color de fondo es gris, se sale
            else if (Buttons[row, column].Boton.BackColor == Color.Gray)
            {
                return false;
            }
            //Si la imagen de fondo es bandera o interrogacion se sale
            else if (Buttons[row, column].Boton.Image == Images["Bandera"])
            {
                return false;
            }
            else if (Buttons[row, column].Bomba)
            {
                return true;
            }
            //Si hay un numero se escribe el numero y para
            else
            {
                Buttons[row, column].Boton.BackColor = Color.Gray;
                if (Buttons[row,column].Number > 0)
                {
                    Buttons[row, column].Boton.ForeColor =
                    GetColor(Buttons[row, column].Number);
                    Buttons[row, column].Boton.Text =
                        "" + Buttons[row, column].Number;
                }
                else
                {
                    LimpiaCasilla(row - 1, column - 1);
                    LimpiaCasilla(row, column - 1);
                    LimpiaCasilla(row + 1, column - 1);
                    LimpiaCasilla(row + 1, column);
                    LimpiaCasilla(row + 1, column + 1);
                    LimpiaCasilla(row, column + 1);
                    LimpiaCasilla(row - 1, column + 1);
                    LimpiaCasilla(row - 1, column);
                }
                return false;
            }
        }
    }
}
