﻿using Ideawrit.Entities.Concrete;
using Ideawrit.Shared.Data.Abstract;
using Ideawrit.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideawrit.Entities.Dtos
{
    public class ArticleDto:DtoGetBase
    {
        public Article Article { get; set; }
        
    }
}
