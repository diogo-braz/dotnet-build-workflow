using Basics.Units;
using Xunit;

namespace Basics;

public class TodoListTests
{
    [Fact]
    public void Add_SavesTodoItem()
    {
        var list = new TodoList();

        list.Add(new("Test Content"));

        var savedItem = Assert.Single(list.All);
        Assert.NotNull(savedItem);
        Assert.Equal(1, savedItem.Id);
        Assert.Equal("Test Content", savedItem.Content);
        Assert.False(savedItem.Complete);
    }

    [Fact]
    public void TodoItemIdIncrementsEveryTimeWeAdd()
    {
        var list = new TodoList();
        
        list.Add(new("Test 1"));
        list.Add(new("Test 2"));

        var items = list.All.ToArray();
        Assert.Equal(1, items[0].Id);
        Assert.Equal(2, items[1].Id);
    }

    [Fact]
    public void Complete_SetsTodoItemCompleteFlagToTrue()
    {
        var list = new TodoList();
        
        list.Add(new("Test 1"));
        list.Complete(1);
        
        var completedItem = Assert.Single(list.All);
        Assert.NotNull(completedItem);
        Assert.Equal(1, completedItem.Id);
        Assert.True(completedItem.Complete);
    }
}