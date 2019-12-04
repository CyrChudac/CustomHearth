using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Runtime.CompilerServices;
using System.IO;

namespace CustomHearth
{
	[System.AttributeUsage(System.AttributeTargets.Class |
					   System.AttributeTargets.Struct)]
	public class CardMakerClass : System.Attribute
	{ }
	[System.AttributeUsage(System.AttributeTargets.Method)]
	public class CardMakerMethod : System.Attribute
	{ }


	public class Database
	{
		private Database()
		{
			SetMethodsForCustomCards();
		}
		static string FolderName => "CustomCards";
		static string LoadFromFolder =>
			Directory.GetParent(
				Directory.GetParent(
					Directory.GetParent(
						Directory.GetCurrentDirectory())
					.Name)
				.Name)
			.FullName + "\\" + FolderName;
		public IEnumerable<Func<Card>> customMethods;
		private void SetMethodsForCustomCards()
		{
			customMethods = new List<Func<Card>>().AsEnumerable();
			if (Directory.Exists(LoadFromFolder))
			{
				try
				{
					customMethods = GetMethodsFromFolder<Card,CardMakerClass,CardMakerMethod>(LoadFromFolder);
				}
				catch (IOException) { }
			}
				
		}

		IEnumerable<Card> GetBlizzardCards()
		{
			throw new NotImplementedException();
		}

		static Database instance = new Database();

		public static IEnumerable<Card> GetCardsThat(Predicate<Card> condition)
		{
			foreach (Card c in instance.GetBlizzardCards())
				if (condition(c))
					yield return c;
			foreach(Func<Card> f in instance.customMethods)
			{
				Card c = f();
				if (condition(c))
					yield return c;
			}
		}
		/// <summary>
		/// Findes all assemblies in a specified directory (and subdirectories) and finds all static methods with specified
		/// attribute and return type that take 0 parameters in classes with given attribute. 
		/// </summary>
		/// <typeparam name="T">return type (or ancestor of it) of methods</typeparam>
		/// <typeparam name="CA">class atribute</typeparam>
		/// <typeparam name="MA">method attribute</typeparam>
		private IEnumerable<Func<T>> GetMethodsFromFolder<T, CA, MA>(string folderName) where CA : Attribute where MA : Attribute
		{
			IEnumerable<Func<T>> allMyMethods = new List<Func<T>>();
			Assembly a;
			try
			{
				foreach (var f in Directory.GetFiles(folderName))
					try
					{
						if ((a = Assembly.LoadFrom(f)) != null)
						{
							var methods = from t in a.GetTypes()
										  where t.IsDefined(typeof(CA))
										  from method in t.GetMethods(BindingFlags.Static)
										  where method.IsDefined(typeof(MA), false)
										  where method.GetParameters().Length == 0
										  where method.ReturnType.IsSubclassOf(typeof(T))
										  select (Func<T>)method.CreateDelegate(typeof(Func<T>));
							allMyMethods = allMyMethods.Concat(methods);
						}
					}
					catch (IOException) { }
			}
			catch (IOException) { }
			foreach (var f in Directory.GetDirectories(folderName))
				allMyMethods = allMyMethods.Concat(GetMethodsFromFolder<T,CA,MA>(f));
			return allMyMethods;
		}
	}
}
