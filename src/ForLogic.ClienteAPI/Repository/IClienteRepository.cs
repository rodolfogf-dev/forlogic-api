﻿using ForLogic.ClienteAPI.Data.ValueObjects;

namespace ForLogic.ClienteAPI.Repository
{
    public interface IClienteRepository
    {
        Task<IEnumerable<ClienteVO>> ObterTodos();
        Task<ClienteVO> ObterPorId(long id);
        Task<ClienteVO> ObterPorCnpj(string cnpj);
        Task<IEnumerable<ClienteVO>> PesquisarPorNome(string nome);
        Task<ClienteVO> Criar(ClienteVO vo);
        Task<ClienteVO> Atualizar(ClienteVO vo);
        Task<bool> Deletar(long id);
    }
}
