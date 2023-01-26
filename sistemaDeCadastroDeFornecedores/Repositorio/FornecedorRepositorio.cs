using sistemaDeCadastroDeFornecedores.Data;
using sistemaDeCadastroDeFornecedores.Models;

namespace sistemaDeCadastroDeFornecedores.Repositorio
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly BancoContext _bancoContext;
        public FornecedorRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public FornecedorModel ListarPorId(int id)
        {
            return _bancoContext.Fornecedor.FirstOrDefault(x => x.Id == id);
        }

        public List<FornecedorModel> BuscarTodos()
        {
            return _bancoContext.Fornecedor.ToList();
        }
        public FornecedorModel Adicionar(FornecedorModel fornecedor)
        {
            _bancoContext.Fornecedor.Add(fornecedor);
            _bancoContext.SaveChanges();

            return fornecedor;
        }

        public FornecedorModel Atualizar(FornecedorModel fornecedor)
        {
            FornecedorModel fornecedorDB = ListarPorId(fornecedor.Id);

            if (fornecedorDB == null) throw new System.Exception("Houve um erro na atualização do fornecedor!");

            fornecedorDB.Name = fornecedor.Name;
            fornecedorDB.CNPJ = fornecedor.CNPJ;
            fornecedorDB.Especialidade = fornecedor.Especialidade;

            _bancoContext.Fornecedor.Update(fornecedorDB);
            _bancoContext.SaveChanges();

            return fornecedorDB;
        }

        public bool Apagar(int id)
        {
            FornecedorModel fornecedorDB = ListarPorId(id);

            if (fornecedorDB == null) throw new System.Exception("Houve um erro na deleção do contato!");

            _bancoContext.Fornecedor.Remove(fornecedorDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
