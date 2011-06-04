using System;
using System.Collections.Generic;

namespace WebGen.ConceptApp.Domain.Entities {
	public partial class Cliente {
		public Cliente() {
			this.Funcionarios = new List<Funcionario>();
			this.Projetos = new List<Projeto>();
        }
        
        virtual public Int32 ID { get; set; }
        virtual public String Nome { get; set; }
        virtual public String Cnpj { get; set; }
        virtual public String Descricao { get; set; }
        virtual public IList<Funcionario> Funcionarios { get; private set; }
        virtual public IList<Projeto> Projetos { get; private set; }

        public override string ToString()
        {
	        return this.Nome;
        }
	}
}
