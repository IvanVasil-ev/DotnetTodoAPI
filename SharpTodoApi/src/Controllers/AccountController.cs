using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharpTodoApi.Entities;
using SharpTodoApi.Repositories;

namespace SharpTodoApi.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly TodoListContext _context;
        public AccountController(TodoListContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            List<AccountEntity> accounts = await _context.Accounts.ToListAsync();
            return StatusCode(200, accounts);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            AccountEntity account = await _context.Accounts.FirstOrDefaultAsync(account => account.Id == id);
            return StatusCode(200, account);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateById(int id, AccountEntity newAccount)
        {
            AccountEntity account = await _context.Accounts.FirstOrDefaultAsync(account => account.Id == id);
            if (account == null)
            {
                return StatusCode(400, new { mesage = "Account was not found!" });
            }
            else
            {
                account.Email = newAccount.Email;
                account.Password = newAccount.Password;
                account.FirstName = newAccount.FirstName;
                account.LastName = newAccount.LastName;
                await _context.SaveChangesAsync();
                return StatusCode(200);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            AccountEntity account = await _context.Accounts.FirstOrDefaultAsync(account => account.Id == id);
            if (account == null)
            {
                return StatusCode(400, new { mesage = "Account was not found!" });
            }
            else
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
                return StatusCode(204);
            }
        }
    }
}
