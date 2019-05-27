using AutoMapper;
using Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    class TranslationRepository : ITranslationRepository
    {
        private SayItContext _db;
        private Mapper _mapper;
        public TranslationRepository()
        {
            _db = new SayItContext();

            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap <TranslationDTO, Translation>());
            _mapper = new Mapper(config);
        }

        Translation CreateNemTranslation(TranslationDTO NewTranslation)
        {
            Translation TranslationToInsert = _mapper.Map<Translation>(NewTranslation);
            _db.Translations.Add(TranslationToInsert);
            _db.SaveChanges();
            return TranslationToInsert;
        }

        Translation EditTranslation(int Id,TranslationDTO EditedTranslation)
        {
            Translation TranslationToEdit = _db.Translations.Where(testc => testc.Id == Id).First();

            TranslationToEdit = _mapper.Map<Translation>(EditedTranslation);
            _db.SaveChanges();
            return TranslationToEdit;
        }

    }
}
