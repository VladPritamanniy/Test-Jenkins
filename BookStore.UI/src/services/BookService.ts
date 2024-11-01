import axios from "axios";
import { BASE_API_URL } from '../constants/BASE_API_URL';
import { BookItem } from "../interfaces/BookItem";
import { BookCreate } from "../interfaces/BookCreate";

export async function getAllBooks(): Promise<BookItem[]> {
    const { data } = await axios.get(`${BASE_API_URL}api/Book/GetAllBooks`);
    return data;
}

export async function getBookById(id: number): Promise<BookItem> {
    const { data } = await axios.get(`${BASE_API_URL}api/Book/GetBookById?id=${id}`);
    return data;
}

export async function createBook(data: Request) {
    const formData = await data.formData();

    const authorsNameData = formData.get('authorsName') as string;
    const json: string[] = authorsNameData ? JSON.parse(authorsNameData) : [];

    const newBook: BookCreate = {
        title: formData.get('title') as string,
        price: parseFloat(formData.get('price') as string),
        authorsName: json
    };

    await axios.post(`${BASE_API_URL}api/Book/CreateBook`, newBook, {
        headers: {
            'Content-Type': 'multipart/form-data',
        },
    });
}

export async function deleteBookById(id: number) {
    await axios.delete(`${BASE_API_URL}api/Book/DeleteBookById?id=${id}`);
}