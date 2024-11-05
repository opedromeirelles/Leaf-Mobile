using Leaf.Repository.Materiais;
using Leaf_Mobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf_Mobile.Services
{
	public class ProdutoServices
	{
		private readonly ProdutoRepository _produtoRepository;

        public ProdutoServices(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        //GET produto
        public async Task<Produto> GetProduto(int idProduto)
        {
            Produto produto = new Produto();
            try
            {
				if (idProduto != 0)
				{
					produto = await _produtoRepository.GetProdutoByIdAsync(idProduto);
				}
				return produto ?? new Produto();
			}
            catch (Exception ex)
            {

                throw new Exception("Erro ao consultar produto. " + ex.Message);
            }
         

        }

    }
}
