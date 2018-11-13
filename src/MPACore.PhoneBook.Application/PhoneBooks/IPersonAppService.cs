using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MPACore.PhoneBook.PhoneBooks.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MPACore.PhoneBook.PhoneBooks
{
    public interface IPersonAppService:IApplicationService
    {
        /// <summary>
        /// 获取列表，支持分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PersonListDto>> GetPagedPersonAsync(GetPersonInput input);

        /// <summary>
        /// 根据ID获取联系人信箱
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input);


        Task CreateOrUpdatePersonAsync(CreteOrUpdatePersonDtoInput input);

        /// <summary>
        /// 删除
        /// </summary> 
        /// <returns></returns>
        Task DeletePersonAsync(EntityDto input);

    }
}
