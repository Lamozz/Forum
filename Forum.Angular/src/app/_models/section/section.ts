import { Theme } from "../theme/theme";

export interface Section {
    id: number;
    title: string;
    description: string;
    categoryid: number;
    themes?: Theme[];
}