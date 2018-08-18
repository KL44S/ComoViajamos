using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComoViajamos.Mappers.Abstractions
{
    public abstract class Mapper<E, V>
    {
        public abstract E MapViewModel(V viewModel);

        public IList<E> MapViewModels(IList<V> viewModels)
        {
            IList<E> entities = new List<E>();

            foreach (V viewModel in viewModels)
            {
                E entity = this.MapViewModel(viewModel);
                entities.Add(entity);
            }

            return entities;
        }
    }
}
