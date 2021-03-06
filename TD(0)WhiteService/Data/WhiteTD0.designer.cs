﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="AI_TD(0)_White_1")]
	public partial class WhiteTD0DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertASTRATEGY(ASTRATEGY instance);
    partial void UpdateASTRATEGY(ASTRATEGY instance);
    partial void DeleteASTRATEGY(ASTRATEGY instance);
    partial void InsertVSTATE(VSTATE instance);
    partial void UpdateVSTATE(VSTATE instance);
    partial void DeleteVSTATE(VSTATE instance);
    partial void InsertPROB(PROB instance);
    partial void UpdatePROB(PROB instance);
    partial void DeletePROB(PROB instance);
    partial void InsertSTATE(STATE instance);
    partial void UpdateSTATE(STATE instance);
    partial void DeleteSTATE(STATE instance);
    partial void InsertVREWARD(VREWARD instance);
    partial void UpdateVREWARD(VREWARD instance);
    partial void DeleteVREWARD(VREWARD instance);
    #endregion
		
		public WhiteTD0DataContext() : 
				base(global::Data.Properties.Settings.Default.AI_TD_0__White_1ConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public WhiteTD0DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WhiteTD0DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WhiteTD0DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WhiteTD0DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ASTRATEGY> ASTRATEGies
		{
			get
			{
				return this.GetTable<ASTRATEGY>();
			}
		}
		
		public System.Data.Linq.Table<VSTATE> VSTATEs
		{
			get
			{
				return this.GetTable<VSTATE>();
			}
		}
		
		public System.Data.Linq.Table<PROB> PROBs
		{
			get
			{
				return this.GetTable<PROB>();
			}
		}
		
		public System.Data.Linq.Table<STATE> STATEs
		{
			get
			{
				return this.GetTable<STATE>();
			}
		}
		
		public System.Data.Linq.Table<VREWARD> VREWARDs
		{
			get
			{
				return this.GetTable<VREWARD>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ASTRATEGY")]
	public partial class ASTRATEGY : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ANO;
		
		private string _STRATEGY;
		
		private EntitySet<PROB> _PROBs;
		
		private EntitySet<VREWARD> _VREWARDs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnANOChanging(int value);
    partial void OnANOChanged();
    partial void OnSTRATEGYChanging(string value);
    partial void OnSTRATEGYChanged();
    #endregion
		
		public ASTRATEGY()
		{
			this._PROBs = new EntitySet<PROB>(new Action<PROB>(this.attach_PROBs), new Action<PROB>(this.detach_PROBs));
			this._VREWARDs = new EntitySet<VREWARD>(new Action<VREWARD>(this.attach_VREWARDs), new Action<VREWARD>(this.detach_VREWARDs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ANO", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ANO
		{
			get
			{
				return this._ANO;
			}
			set
			{
				if ((this._ANO != value))
				{
					this.OnANOChanging(value);
					this.SendPropertyChanging();
					this._ANO = value;
					this.SendPropertyChanged("ANO");
					this.OnANOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STRATEGY", DbType="VarChar(5) NOT NULL", CanBeNull=false)]
		public string STRATEGY
		{
			get
			{
				return this._STRATEGY;
			}
			set
			{
				if ((this._STRATEGY != value))
				{
					this.OnSTRATEGYChanging(value);
					this.SendPropertyChanging();
					this._STRATEGY = value;
					this.SendPropertyChanged("STRATEGY");
					this.OnSTRATEGYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ASTRATEGY_PROB", Storage="_PROBs", ThisKey="ANO", OtherKey="ANO")]
		public EntitySet<PROB> PROBs
		{
			get
			{
				return this._PROBs;
			}
			set
			{
				this._PROBs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ASTRATEGY_VREWARD", Storage="_VREWARDs", ThisKey="ANO", OtherKey="ANO")]
		public EntitySet<VREWARD> VREWARDs
		{
			get
			{
				return this._VREWARDs;
			}
			set
			{
				this._VREWARDs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_PROBs(PROB entity)
		{
			this.SendPropertyChanging();
			entity.ASTRATEGY = this;
		}
		
		private void detach_PROBs(PROB entity)
		{
			this.SendPropertyChanging();
			entity.ASTRATEGY = null;
		}
		
		private void attach_VREWARDs(VREWARD entity)
		{
			this.SendPropertyChanging();
			entity.ASTRATEGY = this;
		}
		
		private void detach_VREWARDs(VREWARD entity)
		{
			this.SendPropertyChanging();
			entity.ASTRATEGY = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VSTATE")]
	public partial class VSTATE : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _SNO;
		
		private double _VALUE;
		
		private EntityRef<STATE> _STATE;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSNOChanging(int value);
    partial void OnSNOChanged();
    partial void OnVALUEChanging(double value);
    partial void OnVALUEChanged();
    #endregion
		
		public VSTATE()
		{
			this._STATE = default(EntityRef<STATE>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SNO", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int SNO
		{
			get
			{
				return this._SNO;
			}
			set
			{
				if ((this._SNO != value))
				{
					if (this._STATE.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSNOChanging(value);
					this.SendPropertyChanging();
					this._SNO = value;
					this.SendPropertyChanged("SNO");
					this.OnSNOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VALUE", DbType="Float NOT NULL")]
		public double VALUE
		{
			get
			{
				return this._VALUE;
			}
			set
			{
				if ((this._VALUE != value))
				{
					this.OnVALUEChanging(value);
					this.SendPropertyChanging();
					this._VALUE = value;
					this.SendPropertyChanged("VALUE");
					this.OnVALUEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="STATE_VSTATE", Storage="_STATE", ThisKey="SNO", OtherKey="SNO", IsForeignKey=true)]
		public STATE STATE
		{
			get
			{
				return this._STATE.Entity;
			}
			set
			{
				STATE previousValue = this._STATE.Entity;
				if (((previousValue != value) 
							|| (this._STATE.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._STATE.Entity = null;
						previousValue.VSTATE = null;
					}
					this._STATE.Entity = value;
					if ((value != null))
					{
						value.VSTATE = this;
						this._SNO = value.SNO;
					}
					else
					{
						this._SNO = default(int);
					}
					this.SendPropertyChanged("STATE");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PROB")]
	public partial class PROB : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _SNO;
		
		private int _ANO;
		
		private int _NSNO;
		
		private int _TIMES;
		
		private EntityRef<ASTRATEGY> _ASTRATEGY;
		
		private EntityRef<STATE> _STATE;
		
		private EntityRef<STATE> _STATE1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSNOChanging(int value);
    partial void OnSNOChanged();
    partial void OnANOChanging(int value);
    partial void OnANOChanged();
    partial void OnNSNOChanging(int value);
    partial void OnNSNOChanged();
    partial void OnTIMESChanging(int value);
    partial void OnTIMESChanged();
    #endregion
		
		public PROB()
		{
			this._ASTRATEGY = default(EntityRef<ASTRATEGY>);
			this._STATE = default(EntityRef<STATE>);
			this._STATE1 = default(EntityRef<STATE>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SNO", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int SNO
		{
			get
			{
				return this._SNO;
			}
			set
			{
				if ((this._SNO != value))
				{
					if (this._STATE1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSNOChanging(value);
					this.SendPropertyChanging();
					this._SNO = value;
					this.SendPropertyChanged("SNO");
					this.OnSNOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ANO", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ANO
		{
			get
			{
				return this._ANO;
			}
			set
			{
				if ((this._ANO != value))
				{
					if (this._ASTRATEGY.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnANOChanging(value);
					this.SendPropertyChanging();
					this._ANO = value;
					this.SendPropertyChanged("ANO");
					this.OnANOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NSNO", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int NSNO
		{
			get
			{
				return this._NSNO;
			}
			set
			{
				if ((this._NSNO != value))
				{
					if (this._STATE.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnNSNOChanging(value);
					this.SendPropertyChanging();
					this._NSNO = value;
					this.SendPropertyChanged("NSNO");
					this.OnNSNOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TIMES", DbType="Int NOT NULL")]
		public int TIMES
		{
			get
			{
				return this._TIMES;
			}
			set
			{
				if ((this._TIMES != value))
				{
					this.OnTIMESChanging(value);
					this.SendPropertyChanging();
					this._TIMES = value;
					this.SendPropertyChanged("TIMES");
					this.OnTIMESChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ASTRATEGY_PROB", Storage="_ASTRATEGY", ThisKey="ANO", OtherKey="ANO", IsForeignKey=true)]
		public ASTRATEGY ASTRATEGY
		{
			get
			{
				return this._ASTRATEGY.Entity;
			}
			set
			{
				ASTRATEGY previousValue = this._ASTRATEGY.Entity;
				if (((previousValue != value) 
							|| (this._ASTRATEGY.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ASTRATEGY.Entity = null;
						previousValue.PROBs.Remove(this);
					}
					this._ASTRATEGY.Entity = value;
					if ((value != null))
					{
						value.PROBs.Add(this);
						this._ANO = value.ANO;
					}
					else
					{
						this._ANO = default(int);
					}
					this.SendPropertyChanged("ASTRATEGY");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="STATE_PROB", Storage="_STATE", ThisKey="NSNO", OtherKey="SNO", IsForeignKey=true)]
		public STATE STATE
		{
			get
			{
				return this._STATE.Entity;
			}
			set
			{
				STATE previousValue = this._STATE.Entity;
				if (((previousValue != value) 
							|| (this._STATE.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._STATE.Entity = null;
						previousValue.PROBs.Remove(this);
					}
					this._STATE.Entity = value;
					if ((value != null))
					{
						value.PROBs.Add(this);
						this._NSNO = value.SNO;
					}
					else
					{
						this._NSNO = default(int);
					}
					this.SendPropertyChanged("STATE");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="STATE_PROB1", Storage="_STATE1", ThisKey="SNO", OtherKey="SNO", IsForeignKey=true)]
		public STATE STATE1
		{
			get
			{
				return this._STATE1.Entity;
			}
			set
			{
				STATE previousValue = this._STATE1.Entity;
				if (((previousValue != value) 
							|| (this._STATE1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._STATE1.Entity = null;
						previousValue.PROBs1.Remove(this);
					}
					this._STATE1.Entity = value;
					if ((value != null))
					{
						value.PROBs1.Add(this);
						this._SNO = value.SNO;
					}
					else
					{
						this._SNO = default(int);
					}
					this.SendPropertyChanged("STATE1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.STATE")]
	public partial class STATE : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _SNO;
		
		private string _MSTATE;
		
		private EntityRef<VSTATE> _VSTATE;
		
		private EntitySet<PROB> _PROBs;
		
		private EntitySet<PROB> _PROBs1;
		
		private EntitySet<VREWARD> _VREWARDs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSNOChanging(int value);
    partial void OnSNOChanged();
    partial void OnMSTATEChanging(string value);
    partial void OnMSTATEChanged();
    #endregion
		
		public STATE()
		{
			this._VSTATE = default(EntityRef<VSTATE>);
			this._PROBs = new EntitySet<PROB>(new Action<PROB>(this.attach_PROBs), new Action<PROB>(this.detach_PROBs));
			this._PROBs1 = new EntitySet<PROB>(new Action<PROB>(this.attach_PROBs1), new Action<PROB>(this.detach_PROBs1));
			this._VREWARDs = new EntitySet<VREWARD>(new Action<VREWARD>(this.attach_VREWARDs), new Action<VREWARD>(this.detach_VREWARDs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SNO", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int SNO
		{
			get
			{
				return this._SNO;
			}
			set
			{
				if ((this._SNO != value))
				{
					this.OnSNOChanging(value);
					this.SendPropertyChanging();
					this._SNO = value;
					this.SendPropertyChanged("SNO");
					this.OnSNOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MSTATE", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string MSTATE
		{
			get
			{
				return this._MSTATE;
			}
			set
			{
				if ((this._MSTATE != value))
				{
					this.OnMSTATEChanging(value);
					this.SendPropertyChanging();
					this._MSTATE = value;
					this.SendPropertyChanged("MSTATE");
					this.OnMSTATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="STATE_VSTATE", Storage="_VSTATE", ThisKey="SNO", OtherKey="SNO", IsUnique=true, IsForeignKey=false)]
		public VSTATE VSTATE
		{
			get
			{
				return this._VSTATE.Entity;
			}
			set
			{
				VSTATE previousValue = this._VSTATE.Entity;
				if (((previousValue != value) 
							|| (this._VSTATE.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._VSTATE.Entity = null;
						previousValue.STATE = null;
					}
					this._VSTATE.Entity = value;
					if ((value != null))
					{
						value.STATE = this;
					}
					this.SendPropertyChanged("VSTATE");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="STATE_PROB", Storage="_PROBs", ThisKey="SNO", OtherKey="NSNO")]
		public EntitySet<PROB> PROBs
		{
			get
			{
				return this._PROBs;
			}
			set
			{
				this._PROBs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="STATE_PROB1", Storage="_PROBs1", ThisKey="SNO", OtherKey="SNO")]
		public EntitySet<PROB> PROBs1
		{
			get
			{
				return this._PROBs1;
			}
			set
			{
				this._PROBs1.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="STATE_VREWARD", Storage="_VREWARDs", ThisKey="SNO", OtherKey="SNO")]
		public EntitySet<VREWARD> VREWARDs
		{
			get
			{
				return this._VREWARDs;
			}
			set
			{
				this._VREWARDs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_PROBs(PROB entity)
		{
			this.SendPropertyChanging();
			entity.STATE = this;
		}
		
		private void detach_PROBs(PROB entity)
		{
			this.SendPropertyChanging();
			entity.STATE = null;
		}
		
		private void attach_PROBs1(PROB entity)
		{
			this.SendPropertyChanging();
			entity.STATE1 = this;
		}
		
		private void detach_PROBs1(PROB entity)
		{
			this.SendPropertyChanging();
			entity.STATE1 = null;
		}
		
		private void attach_VREWARDs(VREWARD entity)
		{
			this.SendPropertyChanging();
			entity.STATE = this;
		}
		
		private void detach_VREWARDs(VREWARD entity)
		{
			this.SendPropertyChanging();
			entity.STATE = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VREWARD")]
	public partial class VREWARD : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _SNO;
		
		private int _ANO;
		
		private int _TIMES;
		
		private double _REWARD;
		
		private int _TOTAL;
		
		private EntityRef<ASTRATEGY> _ASTRATEGY;
		
		private EntityRef<STATE> _STATE;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSNOChanging(int value);
    partial void OnSNOChanged();
    partial void OnANOChanging(int value);
    partial void OnANOChanged();
    partial void OnTIMESChanging(int value);
    partial void OnTIMESChanged();
    partial void OnREWARDChanging(double value);
    partial void OnREWARDChanged();
    partial void OnTOTALChanging(int value);
    partial void OnTOTALChanged();
    #endregion
		
		public VREWARD()
		{
			this._ASTRATEGY = default(EntityRef<ASTRATEGY>);
			this._STATE = default(EntityRef<STATE>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SNO", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int SNO
		{
			get
			{
				return this._SNO;
			}
			set
			{
				if ((this._SNO != value))
				{
					if (this._STATE.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSNOChanging(value);
					this.SendPropertyChanging();
					this._SNO = value;
					this.SendPropertyChanged("SNO");
					this.OnSNOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ANO", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ANO
		{
			get
			{
				return this._ANO;
			}
			set
			{
				if ((this._ANO != value))
				{
					if (this._ASTRATEGY.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnANOChanging(value);
					this.SendPropertyChanging();
					this._ANO = value;
					this.SendPropertyChanged("ANO");
					this.OnANOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TIMES", DbType="Int NOT NULL")]
		public int TIMES
		{
			get
			{
				return this._TIMES;
			}
			set
			{
				if ((this._TIMES != value))
				{
					this.OnTIMESChanging(value);
					this.SendPropertyChanging();
					this._TIMES = value;
					this.SendPropertyChanged("TIMES");
					this.OnTIMESChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_REWARD", DbType="Float NOT NULL")]
		public double REWARD
		{
			get
			{
				return this._REWARD;
			}
			set
			{
				if ((this._REWARD != value))
				{
					this.OnREWARDChanging(value);
					this.SendPropertyChanging();
					this._REWARD = value;
					this.SendPropertyChanged("REWARD");
					this.OnREWARDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TOTAL", DbType="Int NOT NULL")]
		public int TOTAL
		{
			get
			{
				return this._TOTAL;
			}
			set
			{
				if ((this._TOTAL != value))
				{
					this.OnTOTALChanging(value);
					this.SendPropertyChanging();
					this._TOTAL = value;
					this.SendPropertyChanged("TOTAL");
					this.OnTOTALChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ASTRATEGY_VREWARD", Storage="_ASTRATEGY", ThisKey="ANO", OtherKey="ANO", IsForeignKey=true)]
		public ASTRATEGY ASTRATEGY
		{
			get
			{
				return this._ASTRATEGY.Entity;
			}
			set
			{
				ASTRATEGY previousValue = this._ASTRATEGY.Entity;
				if (((previousValue != value) 
							|| (this._ASTRATEGY.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ASTRATEGY.Entity = null;
						previousValue.VREWARDs.Remove(this);
					}
					this._ASTRATEGY.Entity = value;
					if ((value != null))
					{
						value.VREWARDs.Add(this);
						this._ANO = value.ANO;
					}
					else
					{
						this._ANO = default(int);
					}
					this.SendPropertyChanged("ASTRATEGY");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="STATE_VREWARD", Storage="_STATE", ThisKey="SNO", OtherKey="SNO", IsForeignKey=true)]
		public STATE STATE
		{
			get
			{
				return this._STATE.Entity;
			}
			set
			{
				STATE previousValue = this._STATE.Entity;
				if (((previousValue != value) 
							|| (this._STATE.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._STATE.Entity = null;
						previousValue.VREWARDs.Remove(this);
					}
					this._STATE.Entity = value;
					if ((value != null))
					{
						value.VREWARDs.Add(this);
						this._SNO = value.SNO;
					}
					else
					{
						this._SNO = default(int);
					}
					this.SendPropertyChanged("STATE");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
