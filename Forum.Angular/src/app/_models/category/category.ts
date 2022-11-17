import { Section } from "../section/section"

export interface Category {
    id: number;
    title: string;
    sections?: Section[];

}