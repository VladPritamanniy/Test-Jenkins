import { useEffect, useState } from "react"
import { deleteBookById, getAllBooks } from "../../services/BookService";
import { BookItem } from "../../interfaces/BookItem";
import styles from './Home.module.scss';
import { NavLink } from "react-router-dom";

export default function Home() {
    const [books, setBooks] = useState<BookItem[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchData = async () => {
            const response = await getAllBooks();
            setBooks(response);
            setLoading(false);
        };
        fetchData();
    }, []);

    async function handleDeleteBookById(bookId: number) {
        await deleteBookById(bookId);
        setBooks(prevBooks => prevBooks.filter(book => book.id !== bookId));
    }

    return (
        <>
            {loading
                ? <span>loading...</span>
                :
                (<>
                    <NavLink to="/create" className={styles.createNewBookBtn}>NEW</NavLink>
                    <ul className={styles.booksContainer}>
                        {books.map((book) =>
                            <li key={book.id} className={styles.bookItem}>
                                <div className={styles.bookInfo}>
                                    <h3 className={styles.bookTitle}>{book.title}</h3>
                                    <ul className={styles.authorsNameContainer}>
                                        {book.authorsName.map((name) =>
                                            <li key={name} className={styles.authorNameContainer}>
                                                <h6 className={styles.authorName}>&nbsp;{name},</h6>
                                            </li>
                                        )}
                                    </ul>
                                    <h4 className={styles.bookPrice}>{book.price} $</h4>
                                </div>
                                <div className={styles.bookDeleteBtn}>
                                    <button onClick={() => handleDeleteBookById(book.id)} className={styles.deleteBtn}>DELETE</button>
                                    <button className={styles.changeBtn}>CHANGE</button>
                                </div>
                            </li>
                        )}
                    </ul>
                </>)
            }

        </>
    )
}