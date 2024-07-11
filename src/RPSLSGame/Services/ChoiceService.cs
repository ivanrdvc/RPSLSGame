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
        var choices = await _context.Choices
            .AsNoTracking()
            .Select(c => ChoiceModel.FromDomain(c))
            .ToListAsync();

        return choices;
    }

    public async Task<ChoiceModel> GetRandomChoiceAsync()
    {
        var choices = await _context.Choices
            .AsNoTracking()
            .ToListAsync();

        var randomChoice = choices[_random.Next(choices.Count)];

        return ChoiceModel.FromDomain(randomChoice);
    }
}
