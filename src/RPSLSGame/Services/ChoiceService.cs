using Microsoft.EntityFrameworkCore;
using RPSLSGame.Data;
using RPSLSGame.Models;

namespace RPSLSGame.Services;

public class ChoiceService : IChoiceService
{
    private readonly GameDbContext _context;
    private readonly Random _random;

    public ChoiceService(GameDbContext context)
    {
        _context = context;
        _random = new Random();
    }

    public async Task<List<ChoiceModel>> GetChoicesAsync()
    {
        var choices = await _context.Choices.Select(
                c => new ChoiceModel { Id = c.Id, Name = c.Name })
            .ToListAsync();

        return choices;
    }

    public async Task<ChoiceModel> GetRandomChoiceAsync()
    {
        var choices = await _context.Choices.ToListAsync();
        var randomChoice = choices[_random.Next(choices.Count)];

        return new ChoiceModel { Id = randomChoice.Id, Name = randomChoice.Name };
    }
}
