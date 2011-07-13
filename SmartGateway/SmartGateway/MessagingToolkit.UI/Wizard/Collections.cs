//===============================================================================
// OSML - Open Source Messaging Library
//
//===============================================================================
// Copyright © TWIT88.COM.  All rights reserved.
//
// This file is part of Open Source Messaging Library.
//
// Open Source Messaging Library is free software: you can redistribute it 
// and/or modify it under the terms of the GNU General Public License version 3.
//
// Open Source Messaging Library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this software.  If not, see <http://www.gnu.org/licenses/>.
//===============================================================================
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace MessagingToolkit.UI
{
	public class WizardStepDictionary : IDictionary, ICollection, IEnumerable, ICloneable
	{
		protected Hashtable innerHash;
		
		#region "Constructors"
		public WizardStepDictionary()
		{
			innerHash = new Hashtable();
		}
		public WizardStepDictionary(WizardStepDictionary original)
		{
			innerHash = new Hashtable (original.innerHash);
		}
		public WizardStepDictionary(IDictionary dictionary)
		{
			innerHash = new Hashtable (dictionary);
		}

		public WizardStepDictionary(int capacity)
		{
			innerHash = new Hashtable(capacity);
		}
		#endregion

		#region Implementation of IDictionary
		public WizardStepDictionaryEnumerator GetEnumerator()
		{
			return new WizardStepDictionaryEnumerator(this);
		}
		System.Collections.IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new WizardStepDictionaryEnumerator(this);
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Remove(string key)
		{
			innerHash.Remove (key);
		}
		void IDictionary.Remove(object key)
		{
			Remove ((string)key);
		}

		public bool Contains(string key)
		{
			return innerHash.Contains(key);
		}
		bool IDictionary.Contains(object key)
		{
			return Contains((string)key);
		}

		public void Clear()
		{
			innerHash.Clear();		
		}

		public void Add(string key, BaseStep value)
		{
			innerHash.Add (key, value);
		}
		void IDictionary.Add(object key, object value)
		{
			Add ((string)key, (BaseStep)value);
		}

		public bool IsReadOnly
		{
			get
			{
				return innerHash.IsReadOnly;
			}
		}

		public BaseStep this[string key]
		{
			get
			{
				return (BaseStep) innerHash[key];
			}
			set
			{
				innerHash[key] = value;
			}
		}
		object IDictionary.this[object key]
		{
			get
			{
				return this[(string)key];
			}
			set
			{
				this[(string)key] = (BaseStep)value;
			}
		}
        
		public System.Collections.ICollection Values
		{
			get
			{
				return innerHash.Values;
			}
		}

		public System.Collections.ICollection Keys
		{
			get
			{
				return innerHash.Keys;
			}
		}

		public bool IsFixedSize
		{
			get
			{
				return innerHash.IsFixedSize;
			}
		}
		#endregion

		#region Implementation of ICollection
		public void CopyTo(System.Array array, int index)
		{
			innerHash.CopyTo (array, index);
		}

		public void CopyTo(WizardStepDictionary wsc, int index)
		{
			IEnumerator keys = Keys.GetEnumerator();
			IEnumerator values = Values.GetEnumerator();

			int count = Count;

			for(int i = 0; i < index; i++)
			{
				keys.MoveNext();
				values.MoveNext();
			}

			for(int i = index; i < count; i++)
			{
				keys.MoveNext();
				values.MoveNext();

				wsc.Add( keys.Current as string, values.Current as BaseStep );
			}
		}

		public bool IsSynchronized
		{
			get
			{
				return innerHash.IsSynchronized;
			}
		}

		public int Count
		{
			get
			{
				return innerHash.Count;
			}
		}

		public object SyncRoot
		{
			get
			{
				return innerHash.SyncRoot;
			}
		}
		#endregion

		#region Implementation of ICloneable
		public WizardStepDictionary Clone()
		{
			WizardStepDictionary clone = new WizardStepDictionary();
			clone.innerHash = (Hashtable) innerHash.Clone();
			
			return clone;
		}
		object ICloneable.Clone()
		{
			return Clone();
		}
		#endregion
		
		#region "HashTable Methods"
		public bool ContainsKey (string key)
		{
			return innerHash.ContainsKey(key);
		}
		public bool ContainsValue (BaseStep value)
		{
			return innerHash.ContainsValue(value);
		}

		public WizardStepDictionary Synchronized()
		{
			WizardStepDictionary sync = new WizardStepDictionary();
			sync.innerHash = Hashtable.Synchronized(innerHash);

			return sync;
		}
		#endregion

		public class WizardStepDictionaryEnumerator : IDictionaryEnumerator
		{
			private IDictionaryEnumerator innerEnumerator;
			
			internal WizardStepDictionaryEnumerator(WizardStepDictionary enumerable)
			{
				innerEnumerator = enumerable.innerHash.GetEnumerator();
			}

			#region Implementation of IDictionaryEnumerator
			public string Key
			{
				get
				{
					return (string)innerEnumerator.Key;
				}
			}
			object IDictionaryEnumerator.Key
			{
				get
				{
					return Key;
				}
			}


			public BaseStep Value
			{
				get
				{
					return (BaseStep)innerEnumerator.Value;
				}
			}
			object IDictionaryEnumerator.Value
			{
				get
				{
					return Value;
				}
			}

			public System.Collections.DictionaryEntry Entry
			{
				get
				{
					return innerEnumerator.Entry;
				}
			}

			#endregion

			#region Implementation of IEnumerator
			public void Reset()
			{
				innerEnumerator.Reset();
			}

			public bool MoveNext()
			{
				return innerEnumerator.MoveNext();
			}

			object IEnumerator.Current
			{
				get
				{
					return innerEnumerator.Current;
				}
			}

			public DictionaryEntry Current
			{
				get
				{
					return Entry;
				}
			}
			#endregion
		}
	}

}