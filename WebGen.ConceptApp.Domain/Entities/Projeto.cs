using System;
using System.Collections.Generic;

namespace WebGen.ConceptApp.Domain.Entities {
	public partial class Projeto {
		public Projeto() {
			this.Cliente = new Cliente();
			this.Tarefas = new List<Tarefa>();
        }
        
        virtual public Int32 ID { get; set; }

        virtual public String Nome { get; set; }

        virtual public Cliente Cliente { get; private set; }
        virtual public IList<Tarefa> Tarefas { get; private set; }

        public override string ToString()
        {
	        return this.Nome;
        }
	}
}
