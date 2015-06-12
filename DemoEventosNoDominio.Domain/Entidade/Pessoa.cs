using System;

namespace DemoEventosNoDominio.Domain.Entidade
{
    //Declaração do delegate
    public delegate void ControleDeIdadeEventHandler(object source, EventArgs e);

    public class Pessoa
    {
        public Pessoa(string nome, int idade)
        {
            ID = Guid.NewGuid();
            Nome = nome;
            Idade = idade;
        }

        //declaração do evento
        public event ControleDeIdadeEventHandler ExcedeuIdadeLimite;

        private readonly int _idadeMinima = 18;
        private int _idade;

        public Guid ID { get; private set; }
        public string Nome { get; private set; }
        
        public int Idade
        {
            get
            {
                return _idade;
            }
            private set
            {
                //Disparando o evento
                if (value < _idadeMinima)
                    OnIdadeExcedida(new EventArgs());

                _idade = value;
            }
        }


        //Método apontado pelo delegate
        public virtual void OnIdadeExcedida(EventArgs e)
        {
            if (ExcedeuIdadeLimite != null)
                ExcedeuIdadeLimite(this, e);
        }

        public void AlterarIdade(int idade)
        {
            this.Idade = idade;
        }
    }
}
