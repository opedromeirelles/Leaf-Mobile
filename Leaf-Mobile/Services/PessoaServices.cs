using Leaf.Repository.Agentes;
using Leaf_Mobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf_Mobile.Services
{
	public class PessoaServices
	{
		private readonly PessoaRepository _pessoaRepository;

        public PessoaServices(PessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        //GET Pessoa
        public async Task<Pessoa> GetPessoa(int idPessoa)
        {
            Pessoa pessoa = new Pessoa();
            try
            {
				if (idPessoa != 0)
				{
					pessoa = await _pessoaRepository.GetPessoaByIdAsync(idPessoa);
				}

				return pessoa ?? new Pessoa();
			}
            catch (Exception ex)
            {

                throw new Exception("Erro ao consultar pessoa. " + ex.Message);
            }
           
        }

    }
}
