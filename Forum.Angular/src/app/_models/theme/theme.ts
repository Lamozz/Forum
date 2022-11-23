import { Message } from "../message/message"
import { User } from "../user/user"

export interface Theme {
    id: number;
    title: string;
    description: string;
    creatingTime: Date;
    authorId: number;
    sectionId: number;
    author?: User;
    messages?: Message[];
}