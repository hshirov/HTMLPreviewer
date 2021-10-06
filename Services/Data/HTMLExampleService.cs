using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Common.Exceptions;
using System;
using System.Threading.Tasks;

namespace Services.Data
{
    public class HTMLExampleService : IHTMLExampleService
    {
        private readonly ApplicationDbContext _context;
        public HTMLExampleService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new entity to the database, or updated the current one if it already exists
        /// </summary>
        /// <returns>The created or updated entity</returns>
        public async Task<HTMLExample> AddOrUpdate(HTMLExample example)
        {
            if(example != null)
            {
                if(example.Id != 0)
                {
                    var entityToUpdate = await Get(example.Id);
                    example.LastEditedDate = DateTime.Now;
                    example.PreviousHTMLCode = entityToUpdate.HTMLCode;
                    _context.Entry(entityToUpdate).CurrentValues.SetValues(example);
                }
                else
                {
                    await _context.AddAsync(example);
                }

                await _context.SaveChangesAsync();
                return example;
            }
            else
            {
                throw new ArgumentNullException("The HTMLExample argument is null.");
            }
        }

        /// <summary>
        /// Finds an HTMLExample by id and returns it
        /// </summary>
        public async Task<HTMLExample> Get(int id)
        {
            var example = await _context.HTMLExamples.FirstOrDefaultAsync(e => e.Id == id);

            if(example != null)
            {
                return example;
            }

            throw new ExampleNotFoundException(id);
        }
    }
}
