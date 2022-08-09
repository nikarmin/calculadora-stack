﻿using System;

public class NoLista<Dado> where Dado : IComparable<Dado>
{
    Dado info;
    NoLista<Dado> prox;

    public NoLista(Dado novaInfo, NoLista<Dado> proximoNo)
    {
        Info = novaInfo;
        Prox = proximoNo;
    }

    public NoLista(Dado novaInfo)
    {
        Info = novaInfo;
        Prox = null;
    }
    public Dado Info
    {
        get => info;
        set
        {
            if (value != null)
                info = value;
        }
    }

    public NoLista<Dado> Prox 
    { 
        get => prox; 
        set => prox = value; 
    }
}