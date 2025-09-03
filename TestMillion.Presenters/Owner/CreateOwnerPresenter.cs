using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMillion.Presenters;
using TestMillion.DTOs;
using TestMillion.UseCasesPorts.OwnerPorts;

namespace TestMillion.Presenters.Owner
{
    public class CreateOwnerPresenter : ICreateOwnerOutputPort, IPresenter<OwnerDTO>
    {
        public OwnerDTO Content { get; private set; }

        public Task Handle(OwnerDTO owner)
        {
            Content = owner;
            return Task.CompletedTask;
        }
    }
}
