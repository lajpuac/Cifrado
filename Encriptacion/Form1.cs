using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Encriptacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RellenarAlfabeto();
            ControlesDesactivados();
        }
        //Variables globales

        bool Cifrado = true;
        string MensajeMostrado = "";
        int[,] MatrizLlave = new int[3, 3];
        int Controlador = 0;
        Char[] Alfabeto = new char[27];
        List<LetraMensaje> LetrasMensaje = new List<LetraMensaje>();
        List<int[]> ArregloMensaje = new List<int[]>();
        List<LetraMatriz> LetrasMatriz = new List<LetraMatriz>();

        int[] matrizLetrasMensajeM1 = new int[3];
        int[] matrizLetrasMensajeM2 = new int[3];

        int[,] matrizDeterminante = new int[3, 5];

        #region Inicio
        public void RellenarAlfabeto()
        {
            Alfabeto[0] = 'A';
            Alfabeto[1] = 'B';
            Alfabeto[2] = 'C';
            Alfabeto[3] = 'D';
            Alfabeto[4] = 'E';
            Alfabeto[5] = 'F';
            Alfabeto[6] = 'G';
            Alfabeto[7] = 'H';
            Alfabeto[8] = 'I';
            Alfabeto[9] = 'J';
            Alfabeto[10] = 'K';
            Alfabeto[11] = 'L';
            Alfabeto[12] = 'M';
            Alfabeto[13] = 'N';
            Alfabeto[14] = 'Ñ';
            Alfabeto[15] = 'O';
            Alfabeto[16] = 'P';
            Alfabeto[17] = 'Q';
            Alfabeto[18] = 'R';
            Alfabeto[19] = 'S';
            Alfabeto[20] = 'T';
            Alfabeto[21] = 'U';
            Alfabeto[22] = 'V';
            Alfabeto[23] = 'W';
            Alfabeto[24] = 'X';
            Alfabeto[25] = 'Y';
            Alfabeto[26] = 'Z';
        }

        private void Cifrar_Click(object sender, EventArgs e)
        {
            ActivarControles();
            palabraC.Enabled = false;
            palabra.Focus();
        }

        private void Descifrar_Click(object sender, EventArgs e)
        {
            ActivarControles();
            palabra.Enabled = false;
            llave.Focus();
            Cifrado = false;
        }
        public void ControlesDesactivados()
        {
            palabra.Enabled = false;
            palabraC.Enabled = false;
            llave.Enabled = false;
        }
        public void ActivarControles()
        {
            palabra.Enabled = true;
            palabraC.Enabled = true;
            llave.Enabled = true;
            Cifrar.Enabled = true;
        }
        #endregion

        private void convertir_Click(object sender, EventArgs e)
        {
            convertir.Enabled = true;
            string Mensaje = "";
            bool LlaveValida = false;
            if (Cifrado)
            {
                Mensaje = palabra.Text;
            }
            else
            {
                Mensaje = palabraC.Text;
            }
            string Llave = llave.Text;

            LlaveValida = VerificarLlave(Llave);
            if (LlaveValida)
            {
                RellenarMatrizLlave(Llave);
                ColocarMensaje(Mensaje);
                RellenarMatrizMensaje();
                foreach (int[] r in ArregloMensaje)
                {
                    Multiplicaciones(r);
                }
            }
            else
            {
                MessageBox.Show("La llave no es valida");
                palabraC.Text = "";
                llave.Text = "";
                palabra.Text = "";
            }
            if (Cifrado)
            {
                palabraC.Text = MensajeMostrado;
            }
            else
            {
                palabra.Text = MensajeMostrado;
            }

        }


        #region Validaciones

        private void palabra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(e);
        }

        private void llave_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(e);
        }

        private void palabraC_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(e);
        }

        #endregion

        #region Cifrado
        public bool VerificarLlave(string Llave)
        {
            bool LlaveValida = false;
            int contador = 0;
            int Resultado = 0;
            for (int i = 0; i < Llave.Length; i++)
            {
                contador++;
            }
            Resultado = Convert.ToInt32(Math.Sqrt(contador));
            if (Resultado == 3)
            {
                LlaveValida = true;
            }
            else
            {
                LlaveValida = false;
            }
            return LlaveValida;
        }

        public void RellenarMatrizLlave(string Llave)
        {
            int fila = 0;
            int columna = 0;
            for (int i = 0; i < Llave.Length; i++)
            {
                LetraMatriz nuevaLetra = new LetraMatriz();
                nuevaLetra.Letra = Llave[i];
                char Letra = Llave[i];

                nuevaLetra.ValorLetra = ValorCaracter(Letra);
                int ValorLetra = ValorCaracter(Letra);
                LetrasMatriz.Add(nuevaLetra);
                if (fila < MatrizLlave.GetLength(0))
                {
                    if (columna < MatrizLlave.GetLength(1))
                    {
                        MatrizLlave[fila, columna] = ValorLetra;
                    }
                    else
                    {
                        columna = 0;
                        fila++;
                        MatrizLlave[fila, columna] = ValorLetra;

                    }
                }
                columna++;
            }
            if (Cifrado)
            {
                RellenarMatrizLetrasLlave();
            }
            else
            {
                MatrizInversa(MatrizLlave);
                RellenarMatrizLetrasLlave();
            }
        }

        public int ValorCaracter(char Caracter)
        {
            int valor = 0;
            for (int i = 0; i < Alfabeto.Length; i++)
            {
                if (Caracter == Alfabeto[i])
                {
                    valor = i;
                    break;
                }
            }
            return valor;
        }

        public void Multiplicaciones(int[] arreglo)
        {
            int ValorLlave = 0;
            int MOD = 0;
            int ValorMensaje = 0;
            int Resultado = 0;
            char LetraCriptrograma = ' ';

            int i = 0;
            for (int fila = 0; fila < MatrizLlave.GetLength(0); fila++)
            {
                for (int columna = 0; columna < MatrizLlave.GetLength(1); columna++)
                {
                    ValorLlave = MatrizLlave[fila, columna];
                    ValorMensaje = arreglo[i];
                    
                    Resultado += MatrizLlave[fila, columna] * arreglo[i];
                    MOD = Resultado % Alfabeto.Length;
                    LetraCriptrograma = ObtenerLetra(MOD);
                    i++;
                }

                if (Controlador < 3)
                {
                    criptoM1.Text += MOD + " " + LetraCriptrograma + "\n";
                    Controlador++;
                }
                else
                {
                    criptoM2.Text += MOD + " " + LetraCriptrograma + "\n";
                }
                Resultado = 0;
                i = 0;

                MensajeMostrado += LetraCriptrograma;
            }

        }


        public void RellenarMatrizLetrasLlave()
        {
            int contador = 0;
            foreach (LetraMatriz lt in LetrasMatriz)
            {
                contador++;
                if (contador >= 3)
                {
                    contador = 0;
                }
            }
        }

        public void ColocarMensaje(string Mensaje)
        {
            for (int i = 0; i < Mensaje.Length; i++)
            {
                LetraMensaje nuevaLetraMensaje = new LetraMensaje();
                nuevaLetraMensaje.Letra = Mensaje[i];

                int ValorLetra = ValorCaracter(Mensaje[i]);
                nuevaLetraMensaje.ValorLetra = ValorLetra;
                LetrasMensaje.Add(nuevaLetraMensaje);
            }
            MostrarLetrasMensaje();
        }

        public void MostrarLetrasMensaje()
        {
            int contador = 0;
            foreach (LetraMensaje lm in LetrasMensaje)
            {
                if (contador < 3)
                {
                    lm.colocado = true;
                    contador++;
                }
                else
                {
                    lm.colocado = true;
                }
            }
        }

        public void RellenarMatrizMensaje()
        {
            int i = 0;
            bool Terminado = false;
            foreach (LetraMensaje lt in LetrasMensaje)
            {
                if (i < matrizLetrasMensajeM1.Length && Terminado == false)
                {
                    matrizLetrasMensajeM1[i] = lt.ValorLetra;
                    if (i + 1 > 2)
                    {
                        i = 0;
                        ArregloMensaje.Add(matrizLetrasMensajeM1);
                        Terminado = true;
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    if (i < matrizLetrasMensajeM2.Length)
                    {
                        matrizLetrasMensajeM2[i] = lt.ValorLetra;
                        i++;
                        if (i + 1 > 3)
                        {
                            ArregloMensaje.Add(matrizLetrasMensajeM2);
                        }
                    }
                }
            }
        }

        public char ObtenerLetra(int IndiceLetra)
        {
            char caracter = ' ';
            for (int y = 0; y < Alfabeto.Length; y++)
            {
                if (IndiceLetra == y)
                {
                    caracter = Alfabeto[y];
                    break;
                }

            }
            return caracter;
        }

        #endregion

        #region Descifrado

        public void MatrizInversa(int[,] matriz)
        {
            int Determinante = 0;
            ObtenerMatrizDeterminante(matriz);
            int Suma = ObtenerSumaMatrizDeterminante();
            int Resta = ObtenerRestaMatrizDeterminante();
            Determinante = Suma - Resta;
            Determinante = ObtenerDeterminante(Determinante);

            ObtenerMatrizInversa(Determinante);
        }

        public void MatrizInversa(int Determinante)
        {
            LetrasMatriz.Clear();
            int Residuo = 0;
            int valor = 0;

            for (int fila = 0; fila < MatrizLlave.GetLength(0); fila++)
            {
                for (int columna = 0; columna < MatrizLlave.GetLength(1); columna++)
                {
                    MatrizLlave[fila, columna] = MatrizLlave[fila, columna] * Determinante;
                }
            }

            for (int fila = 0; fila < MatrizLlave.GetLength(0); fila++)
            {
                for (int columna = 0; columna < MatrizLlave.GetLength(1); columna++)
                {
                    LetraMatriz nuevaLetra = new LetraMatriz();
                    valor = MatrizLlave[fila, columna];
                    Residuo = valor % Alfabeto.Length;
                    if (Residuo < 0)
                    {
                        Residuo = Residuo * Alfabeto.Length;
                        MatrizLlave[fila, columna] = Residuo;
                    }
                    else
                    {
                        MatrizLlave[fila, columna] = Residuo;
                    }
                    nuevaLetra.ValorLetra = Residuo;
                    nuevaLetra.Letra = ObtenerLetra(Residuo);
                    LetrasMatriz.Add(nuevaLetra);
                }
            }
        }

        public void ObtenerMatrizDeterminante(int[,] matriz)
        {
            int fila = 0;
            int columna = 0;

            foreach (LetraMatriz lt in LetrasMatriz)
            {
                int ValorLetra = lt.ValorLetra;
                if (columna < matrizDeterminante.GetLength(1) && columna < 2)
                {
                    matrizDeterminante[fila, columna] = ValorLetra;
                    matrizDeterminante[fila, columna + 3] = ValorLetra;
                    columna++;
                }
                else
                {
                    matrizDeterminante[fila, columna] = ValorLetra;
                    columna = 0;
                    fila++;
                }
            }
        }

        public int ObtenerSumaMatrizDeterminante()
        {
            int columna = 0;
            int fila = 0;
            int Multiplicacion = 0;
            int suma = 0;

            for (int i = 0; i < 3; i++)
            {
                if (fila < matrizDeterminante.GetLength(0))
                {
                    if (columna < matrizDeterminante.GetLength(1))
                    {
                        Multiplicacion = matrizDeterminante[fila, columna] * matrizDeterminante[fila + 1, columna + 1]
                            * matrizDeterminante[fila + 2, columna + 2];
                        suma += Multiplicacion;
                        columna++;
                    }
                }
            }
            return suma;
        }

        public int ObtenerRestaMatrizDeterminante()
        {
            int columna = 2;
            int fila = 0;
            int Multiplicacion = 0;
            int suma = 0;
            for (int i = 0; i < 3; i++)
            {
                if (fila < matrizDeterminante.GetLength(0))
                {
                    if (columna < matrizDeterminante.GetLength(1))
                    {
                        Multiplicacion = matrizDeterminante[fila, columna] * matrizDeterminante[fila + 1, columna - 1]
                            * matrizDeterminante[fila + 2, columna - 2];
                        suma += Multiplicacion;
                        columna++;
                    }
                }
            }
            return suma;
        }

        public int ObtenerDeterminante(int Determinante)
        {
            Determinante = Determinante % Alfabeto.Length;
            bool Encontrado = false;
            int Num = 1;
            do
            {
                int Resultado = Determinante * Num;
                int Residuo = Resultado % Alfabeto.Length;
                if (Residuo == 1)
                {
                    Encontrado = true;
                }
                else
                {
                    Num++;
                }
            } while (!Encontrado);
            return Num;
        }

        public void ObtenerMatrizInversa(int Determinante)
        {
            int[] matrizAuxiliar = new int[9];
            int i = 0;
            for (int fila = 0; fila < MatrizLlave.GetLength(0); fila++)
            {
                for (int columna = 0; columna < MatrizLlave.GetLength(1); columna++)
                {
                    matrizAuxiliar[i] = ObtenerCofactores(fila, columna);
                    i++;
                }
            }

            i = 0;
            bool Positivo = true;

            for (int j = 0; j < matrizAuxiliar.Length; j++)
            {
                if (Positivo)
                {
                    matrizAuxiliar[j] = matrizAuxiliar[j] * 1;
                    Positivo = false;
                }
                else
                {
                    matrizAuxiliar[j] = matrizAuxiliar[j] * -1;
                    Positivo = true;
                }
            }

            DeterminarMatrizT(matrizAuxiliar);
            MatrizInversa(Determinante);
        }

        public void DeterminarMatrizT(int[] matriz)
        {
            int fila = 0;
            int columna = 0;
            for (int i = 0; i < matriz.Length; i++)
            {
                if (fila < MatrizLlave.GetLength(0))
                {
                    if (columna < MatrizLlave.GetLength(1))
                    {
                        fila++;
                    }
                }
                else
                {
                    columna++;
                    fila = 0;
                    i--;
                }
            }
        }

        public int ObtenerCofactores(int f, int c)
        {
            int[] valores = new int[4];
            int Cofactor = 0;
            int i = 0;
            for (int fila = 0; fila < MatrizLlave.GetLength(0); fila++)
            {
                for (int columna = 0; columna < MatrizLlave.GetLength(1); columna++)
                {
                    if (f != fila && c != columna)
                    {
                        valores[i] = MatrizLlave[fila, columna];
                        i++;
                    }
                }
            }
            i = 0;
            int suma = valores[i] * valores[i + 3];
            int Resta = valores[i + 1] * valores[i + 2];
            Cofactor = suma - Resta;

            return Cofactor;
        }
        #endregion



        private void reiniciar_Click(object sender, EventArgs e)
        {
            palabraC.Text = "";
            llave.Text = "";
            palabra.Text = "";
            criptoM1.Text = "";
            criptoM2.Text = "";
        }
    }
}