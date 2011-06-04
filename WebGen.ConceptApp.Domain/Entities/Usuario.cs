using System;
using System.ComponentModel;

using System.Collections.Generic;

namespace WebGen.ConceptApp.Domain.Entities {
	public partial class Usuario {
		public Usuario() {
			this.TarefasQueEuCriei = new List<Tarefa>();
			this.TarefasQueEuSouResponsavel = new List<Tarefa>();
		}

		virtual public Int32 ID { get; set; }
		
		virtual public String Nome { get; set; }
		
		virtual public IList<Tarefa> TarefasQueEuCriei { get; private set; }
		virtual public IList<Tarefa> TarefasQueEuSouResponsavel { get; private set; }

		public override string ToString()
		{
			return this.Nome;
		}
	}
}
