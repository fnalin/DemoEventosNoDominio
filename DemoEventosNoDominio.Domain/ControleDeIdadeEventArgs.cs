using System;

namespace DemoEventosNoDominio.Domain
{
    //Argumentos que serão disponibilizados no eventos --> herdar de EventArgs
    public class ControleDeIdadeEventArgs : EventArgs
    {
        public int IdadeAntiga { get; set; }
        public int IdadeNova { get; set; }
    }
}
