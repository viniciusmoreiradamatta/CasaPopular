using CasaPopular.Application.Factory;
using CasaPopular.Application.Factory.Base;
using CasaPopular.Application.Interface;
using CasaPopular.Application.ViewModels;
using CasaPopular.Domain.Entities;
using CasaPopular.Domain.Interfaces;
using CasaPopular.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaPopular.Application.Service
{
    public class FamiliaService : IFamiliaService
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IFamiliaRepository _familiaRepository;

        public FamiliaService(IFamiliaRepository familiaRepository, IUnityOfWork unityOfWork)
        {
            _familiaRepository = familiaRepository;
            _unityOfWork = unityOfWork;
        }

        public async Task CadastrarFamilia(CadastroFamiliaViewModel viewModel)
        {
            List<Pessoa> pessoas = new();

            foreach (var item in viewModel.Pessoas)
            {
                pessoas.Add(BaseFactory.CriarPessoas(item));
            }

            var statusCadastro = pessoas.Any(c => string.IsNullOrEmpty(c.Nome)) ? 1 : 3;

            Familia familia = new(statusCadastro, pessoas);

            await _familiaRepository.CadastrarFamilia(familia);

            await _unityOfWork.SaveChanges();
        }

        public async Task ContemplarFamilias()
        {
            var familias = _familiaRepository.ObterTodasFamiliasComtemplaveis();

            foreach (var item in familias)
            {
                List<Criterio> criterios = new()
                {
                    CriterioFactory.CriarCriterio(Domain.Enuns.TipoCriterio.IdadePretendente, item.PontosPorIdadePretendente()),
                    CriterioFactory.CriarCriterio(Domain.Enuns.TipoCriterio.NumeroDependente, item.TotalDependentes()),
                    CriterioFactory.CriarCriterio(Domain.Enuns.TipoCriterio.RendaTotal, item.PontosPorRenda()),
                };

                FamiliaSelecionada familia = new(item.Id, DateTime.Now, item.TotalPontos(), criterios);

                await _familiaRepository.AdicionarSelecao(familia);

                item.ContemplarFamilia();
            }

            await _unityOfWork.SaveChanges();
        }

        public IEnumerable<Familia> ObterTodasFamiliasComtemplaveis()
        {
            return _familiaRepository.ObterTodasFamiliasComtemplaveis();
        }
    }
}