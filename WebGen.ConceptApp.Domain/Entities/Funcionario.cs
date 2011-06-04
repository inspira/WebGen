using System;
using System.Collections.Generic;

namespace WebGen.ConceptApp.Domain.Entities {
	public partial class Funcionario {
		public Funcionario() {
			this.Cliente = new Cliente();
			this.Tarefas = new List<Tarefa>();
        }
        
        virtual public Int32 ID { get; set; }
        virtual public String Nome { get; set; }
        virtual public String CPF { get; set; }
        virtual public String Foto { get; set; }
        virtual public String Email { get; set; }
        virtual public Int32 Idade { get; set; }
        virtual public String TelefoneResidencial { get; set; }
        virtual public String TelefoneComercial { get; set; }
        virtual public String TelefoneCelular { get; set; }
        virtual public String Endereco { get; set; }
        virtual public String CEP { get; set; }
        virtual public DateTime DataNascimento { get; set; }
        virtual public Decimal Salario { get; set; }
        virtual public String InformacoesAdicionais { get; set; }
        virtual public String Perfil { get; set; }
        virtual public Cliente Cliente { get; private set; }
        virtual public IList<Tarefa> Tarefas { get; private set; }

        public override string ToString()
        {
	        return this.Nome;
        }
	}
}
