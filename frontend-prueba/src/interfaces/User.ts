export interface User {
    id: number;
    firstName: string;
    lastName: string;
    maidenName?: string;   // puede no venir
    age: number;
    gender: string;
    email: string;
    username: string;
    password?: string;     // se usa en login, no siempre se devuelve
    birthDate: string;
    image?: string;
    bloodGroup?: string;
  }
  