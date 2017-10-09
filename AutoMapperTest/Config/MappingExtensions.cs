using AutoMapper;
using AutoMapperTest.ApiModels;
using AutoMapperTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest.Config
{
    public static class MappingExtensions
    {
        public static void MapCollection<TS, TT>(this IMapper mapper, IList<TS> sourceCollection, IList<TT> targetCollection, string currentUser) 
            where TS: EntityDto 
            where TT: Entity
        {
            foreach (var source in sourceCollection)
            {
                var target = targetCollection.Where(t => t.Id == source.Id).FirstOrDefault();

                if (target != null)
                {
                    mapper.Map(source, target);
                    target.ModifiedBy = currentUser;
                    target.ModifiedDate = DateTime.UtcNow;
                }
                else
                {
                    target = mapper.Map<TT>(source);
                    target.CreatedBy = currentUser;
                    target.CreatedDate = DateTime.UtcNow;
                    targetCollection.Add(target);
                }
            }

        }
    }
}
