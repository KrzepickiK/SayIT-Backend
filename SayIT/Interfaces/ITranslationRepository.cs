using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITranslationRepository
    {
        Translation CreateNewTranslation(TranslationDTO NewTranslation);
        Translation EditTranslation(int Id,TranslationDTO EditedTranslation);
    }
}
