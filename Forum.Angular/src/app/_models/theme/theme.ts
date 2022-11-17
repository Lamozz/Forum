import { Message } from "../message/message"
import { User } from "../user/user"

export interface Theme {
    id: number;
    title: string;
    description: string;
    creatingTime: Date;
    authorId: number;
    sectionId: number;
    user?: User;
    messages?: Message[];
}