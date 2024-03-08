using Ideawrit.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideawrit.Shared.Data.Abstract
{
    public abstract class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; } //virtual ile sen sanal olmalısın dedik daha sonra kullandığımda override edebilelim.
        
    }
}
