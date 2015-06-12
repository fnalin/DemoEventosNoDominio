using System;

namespace DemoEventosNoDominio.Domain.Entidade
{
    public delegate void ControleDeIdadeEventHandler(object source, EventArgs e);

    public class Pessoa
    {
        public Pessoa(string nome, int idade)
        {
            ID = Guid.NewGuid();
            Nome = nome;
            Idade = idade;
        }

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
                if (value < _idadeMinima)
                    OnIdadeExcedida(new EventArgs());

                _idade = value;
            }
        }


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
