import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpResponse } from '@angular/common/http'
import { Router } from '@angular/router';

export class AppPlanDto{

    public readonly name: string;
    public readonly id: number;
    public readonly done: boolean;
    public QuestDto: Array<AppQuestDto>;

    constructor(id: number, name: string, done: boolean, QuestDto: Array<AppQuestDto> ){        
        this.id = id
        this.name = name
        this.done = done
        this.QuestDto = QuestDto
    }

}

export class AppQuestDto{
    public readonly id: number;
    public readonly disc: string;
    public readonly date: Date;
    public readonly priv: boolean;
    public readonly status: boolean;
    public links: Array<string>;

    constructor(id: number, disc: string, date: Date, priv: boolean, status: boolean, list: Array<string>){        
        this.id = id
        this.disc = disc
        this.date = date
        this.priv = priv
        this.status = status
        this.links = list
    }

}