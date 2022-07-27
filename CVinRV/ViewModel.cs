using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CVinRV;

public class Item
{
	public string Name { get; set; }

	public string Description { get; set; }
}

public class ViewModel : ObservableObject
{
	private bool _isRefreshing;

	private List<Item> _items;

	private async Task Refresh()
	{
		await Task.Delay(500);
		var items = new List<Item>();
		items.Add(new Item() { Name = "Item 1", Description = "The first item." });
		items.Add(new Item() { Name = "Item 2", Description = "The second item." });
		items.Add(new Item() { Name = "Item 3", Description = "The third item." });
		Items = items;
		IsRefreshing = false;
	}

	public bool IsRefreshing
	{
		get => _isRefreshing;

		set
		{
			SetProperty(ref _isRefreshing, value);
		}
	}

	public List<Item> Items 
	{
		get => _items;
		
		set
		{
			SetProperty(ref _items, value);
		}
	}

	public AsyncRelayCommand RefreshCommand { get; private set; }

	public ViewModel()
	{
		_isRefreshing = false;
		_items = null;

		RefreshCommand = new AsyncRelayCommand(Refresh);
	}
}

public static class ViewModelLocator
{
	private static ViewModel _main = null;

	public static ViewModel Main
	{
		get
		{
			if (_main == null)
			{
				_main = new ViewModel();
			}

			return _main;
		}
	}
}