using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using MPACore.PhoneBook.PhoneBooks.Dtos;
using MPACore.PhoneBook.PhoneBooks.Persons;

namespace MPACore.PhoneBook.PhoneBooks
{
    public class PersionAppService : IPersonAppService
    {
        private readonly IRepository<Person> _resposotory;

        public PersionAppService(IRepository<Person> respository)
        {
            _resposotory = respository;
        }


        public async Task CreateOrUpdatePersonAsync(CreteOrUpdatePersonDtoInput input)
        {
            if (input.edit.Id.HasValue)
            {
                await UpdatePersonAsync(input.edit);
            }
            else
            {
                await CreatePersonAsync(input.edit);
            }


            throw new NotImplementedException();
        }

        public async Task DeletePersonAsync(EntityDto input)
        {
            var p = await _resposotory.GetAsync(input.Id);
            if (p == null)
            {
                throw new UserFriendlyException("数据不存在");
            }
            await _resposotory.DeleteAsync(input.Id);
        }

        public async Task<PagedResultDto<PersonListDto>> GetPagedPersonAsync(GetPersonInput input)
        {
            var query = _resposotory.GetAll();
            var personcount = await query.CountAsync();

            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            var dtos = persons.MapTo<List<PersonListDto>>();

            return new PagedResultDto<PersonListDto>(personcount,dtos);
        }

        public async Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input)
        {
            var p = await _resposotory.GetAsync(input.Id.Value);
            return p.MapTo<PersonListDto>();
        }


        protected async Task UpdatePersonAsync(PersonEditDto input)
        {
            var p = await _resposotory.GetAsync(input.Id.Value);
            await _resposotory.UpdateAsync(input.MapTo(p));

        }

        protected async Task CreatePersonAsync(PersonEditDto input)
        {
            await _resposotory.InsertAsync(input.MapTo<Person>());
        }
    }
}
