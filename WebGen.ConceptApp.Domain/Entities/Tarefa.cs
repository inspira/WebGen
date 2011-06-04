using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace WebGen.ConceptApp.Domain.Entities {
	public partial class Tarefa {
		public Tarefa() {
			this.Projeto = new Projeto();
			this.Funcionarios = new List<Funcionario>();
        }
        
        virtual public Int32 ID { get; set; }
        virtual public String Nome { get; set; }
        virtual public Int32 QuantidadeHoras { get; set; }
        virtual public Boolean Finalizado { get; set; }
        virtual public DateTime DataPrazoFinal { get; set; }
        virtual public DateTime DataCriacao { get; set; }
        virtual public Projeto Projeto { get; private set; }
        virtual public IList<Funcionario> Funcionarios { get; private set; }

        public override string ToString()
        {
	        return this.Nome;
        }
	}
}
