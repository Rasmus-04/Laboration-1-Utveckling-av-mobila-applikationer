using Laboration_1_Rasmus_Serrestam.Data;
using Laboration_1_Rasmus_Serrestam.Models;
using Microsoft.EntityFrameworkCore;

namespace Laboration_1_Rasmus_Serrestam.Services
{
    public class ItemService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public ItemService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Item>> GetAllItemsAsync()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            return await context.Items
                .Include(item => item.Condition)
                .OrderBy(item => item.Title)
                .ToListAsync();
        }

        public async Task<Item?> GetItemByIdAsync(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            return await context.Items
                .Include(item => item.Condition)
                .FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task AddItemAsync(Item item)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            context.Items.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task<bool> UpdateItemAsync(Item editedItem)
        {
            await using var context =
                await _contextFactory.CreateDbContextAsync();

            // Hämta den befintliga produkten.
            var existingItem = await context.Items
                .FirstOrDefaultAsync(item => item.Id == editedItem.Id);

            if (existingItem == null)
                return false;

            // Uppdatera produktens egenskaper.
            existingItem.Title = editedItem.Title;
            existingItem.Price = editedItem.Price;
            existingItem.ConditionId = editedItem.ConditionId;
            existingItem.Description = editedItem.Description;
            existingItem.SellerEmail = editedItem.SellerEmail;

            // Spara ändringarna.
            await context.SaveChangesAsync();

            return true;
        }

        public async Task DeleteItemAsync(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            var item = await context.Items.FindAsync(id);

            if (item != null)
            {
                context.Items.Remove(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
