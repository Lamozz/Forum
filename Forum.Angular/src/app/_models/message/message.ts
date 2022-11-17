import { User } from "../user/user"

export interface Message {
    id: number;
    text: string;
    creatingTime: Date;
    authorId: number;
    themeId: number;
    user?: User;
}