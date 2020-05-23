using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Net.Cache;

namespace Test
{


    class Program
    {

        static void Main(string[] args)
        {

            //CustomArray<int> customArray = new CustomArray<int>();

            //customArray.Add(7);
            //customArray.Add(5);
            //customArray.Add(8);
            //customArray[0] = 9;
            //customArray.GetElements();
            //customArray.Remove(8);

            //Console.WriteLine("removed");
            //customArray.GetElements();

            CustomDictionary<string, int> customDictionary = new CustomDictionary<string, int>();

            customDictionary.Add("one", 1);
            customDictionary["one"] = 2;

            Console.WriteLine(customDictionary["one"]); ;
            Console.ReadKey();
        }

    }

    class CustomDictionary<T, R>
    {
        T[] keys = new T[0];
        R[] values = new R[0];
        public R this[T index]
        {
            get
            {

                for (int i = 0; i < keys.Length; i++)
                {
                    if (index.Equals(keys[i]))
                    {
                        return values[i];
                    }

                }

                throw new NotImplementedException();



            }
            set
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    if (index.Equals(keys[i]))
                    {
                        values[i] = value;
                    }
                }
            }
        }

        public void Add(T key, R value)
        {
            T[] tempKeyArray = new T[keys.Length + 1];
            R[] tempValuesArray = new R[keys.Length + 1];
            CopyTo(tempKeyArray, tempValuesArray);

            tempKeyArray[tempKeyArray.Length - 1] = key;
            tempValuesArray[tempKeyArray.Length - 1] = value;
            keys = tempKeyArray;
            values = tempValuesArray;


        }
        public void CopyTo(T[] newKeysArray, R[] newValuesArray)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                newKeysArray[i] = keys[i];
                newValuesArray[i] = values[i];
            }
        }
        public void GetElements()
        {
            for (int i = 0; i < keys.Length; i++)
            {
                Console.WriteLine($"Key {keys[i]} Value {values[i]}");
            }
        }

    }
    class CustomArray<T>
    {
        T[] array = new T[0];

        public T this[int index]
        {
            get
            {
                if (index <= array.Length - 1 && index >= 0)
                {
                    return array[index];
                }
                else
                {
                    throw new NotImplementedException();
                }



            }

            set
            {
                if (index < array.Length && index >= 0)
                {
                    array[index] = value;
                }
            }
        }
        public void Add(T obj)
        {
            T[] tempArray = new T[array.Length + 1];
            CopyTo(tempArray);

            tempArray[array.Length] = obj;
            array = tempArray;
        }

        public void GetElements()
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
        public void CopyTo(T[] newArray)
        {
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
        }

        public void Remove(T obj)
        {
            int j = 0;
            T[] tempArray = new T[array.Length - 1];


            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(obj))
                {
                    continue;
                }
                else
                {
                    tempArray[j] = array[i];
                    j++;
                }

            }
            array = tempArray;

        }
    }







}

