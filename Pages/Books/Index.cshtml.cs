using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aron_Andreea1_Lab2.Data;
using Aron_Andreea1_Lab2.Models;

namespace Aron_Andreea1_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Aron_Andreea1_Lab2.Data.Aron_Andreea1_Lab2Context _context;

        public IndexModel(Aron_Andreea1_Lab2.Data.Aron_Andreea1_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;
        public IList<Author> Authors { get; set; } = default!;
        public SelectListItem AuthorsList { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Book = await _context.Book
                    .Include(b => b.Author)
                    .Include(b => b.Publisher)
                    .ToListAsync();
            }
            if (_context.Author != null)
            {
                Authors = await _context.Author.ToListAsync();

                //AuthorsList = Authors.Select(x => new SelectListItem
                //{
                //    Text = x.FirstName,
                //    Value = x.FirstName
                //}).ToList();
            }
        }
    }
}
