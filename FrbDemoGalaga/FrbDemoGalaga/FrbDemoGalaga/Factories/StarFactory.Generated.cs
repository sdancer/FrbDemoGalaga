using FrbDemoGalaga.Entities;
using System;
using FlatRedBall.Math;
using FlatRedBall.Graphics;
using FrbDemoGalaga.Performance;

namespace FrbDemoGalaga.Factories
{
	public class StarFactory : IEntityFactory
	{
		public static Star CreateNew ()
		{
			return CreateNew(null);
		}
		public static Star CreateNew (Layer layer)
		{
			if (string.IsNullOrEmpty(mContentManagerName))
			{
				throw new System.Exception("You must first initialize the factory to use it.");
			}
			Star instance = null;
			instance = mPool.GetNextAvailable();
			if (instance == null)
			{
				mPool.AddToPool(new Star(mContentManagerName, false));
				instance =  mPool.GetNextAvailable();
			}
			instance.AddToManagers(layer);
			if (mScreenListReference != null)
			{
				mScreenListReference.Add(instance);
			}
			if (EntitySpawned != null)
			{
				EntitySpawned(instance);
			}
			return instance;
		}
		
		public static void Initialize (PositionedObjectList<Star> listFromScreen, string contentManager)
		{
			mContentManagerName = contentManager;
			mScreenListReference = listFromScreen;
			FactoryInitialize();
		}
		
		public static void Destroy ()
		{
			mContentManagerName = null;
			mScreenListReference = null;
			mPool.Clear();
			EntitySpawned = null;
		}
		
		private static void FactoryInitialize ()
		{
			const int numberToPreAllocate = 20;
			for (int i = 0; i < numberToPreAllocate; i++)
			{
				Star instance = new Star(mContentManagerName, false);
				mPool.AddToPool(instance);
			}
		}
		
		/// <summary>
		/// Makes the argument objectToMakeUnused marked as unused.  This method is generated to be used
		/// by generated code.  Use Destroy instead when writing custom code so that your code will behave
		/// the same whether your Entity is pooled or not.
		/// </summary>
		public static void MakeUnused (Star objectToMakeUnused)
		{
			MakeUnused(objectToMakeUnused, true);
		}
		
		/// <summary>
		/// Makes the argument objectToMakeUnused marked as unused.  This method is generated to be used
		/// by generated code.  Use Destroy instead when writing custom code so that your code will behave
		/// the same whether your Entity is pooled or not.
		/// </summary>
		public static void MakeUnused (Star objectToMakeUnused, bool callDestroy)
		{
			mPool.MakeUnused(objectToMakeUnused);
			
			if (callDestroy)
			{
				objectToMakeUnused.Destroy();
			}
		}
		
		
			static string mContentManagerName;
			static PositionedObjectList<Star> mScreenListReference;
			static PoolList<Star> mPool = new PoolList<Star>();
			public static Action<Star> EntitySpawned;
			object IEntityFactory.CreateNew ()
			{
				return StarFactory.CreateNew();
			}
			object IEntityFactory.CreateNew (Layer layer)
			{
				return StarFactory.CreateNew(layer);
			}
			public static PositionedObjectList<Star> ScreenListReference
			{
				get
				{
					return mScreenListReference;
				}
				set
				{
					mScreenListReference = value;
				}
			}
			static StarFactory mSelf;
			public static StarFactory Self
			{
				get
				{
					if (mSelf == null)
					{
						mSelf = new StarFactory();
					}
					return mSelf;
				}
			}
	}
}
