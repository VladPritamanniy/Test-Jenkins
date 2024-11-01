import { ActionFunction, Form, redirect } from "react-router-dom";
import { createBook } from "../../services/BookService";
import styles from './Create.module.scss';
import { useState } from "react";

export const action: ActionFunction = async ({ request }) => {
    await createBook(request);
    return redirect(`/`);
};

export default function Create() {
    const [title, setTitle] = useState('');
    const [price, setPrice] = useState(0);
    const [names, setNames] = useState<string[]>([]);

    const handleInputChange = (index: number, newValue: string) => {
        setNames(names.map((name, i) => i === index ? newValue : name));
    };

    return (
        <>
            <Form className={styles.form} method="post" encType="multipart/form-data">
                <label className={styles.title}>
                    <span>Title</span>
                    <input
                        placeholder="Title"
                        aria-label="Title"
                        type="text"
                        name="title"
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                    />
                </label>
                <label className={styles.price}>
                    <span>Price</span>
                    <input
                        placeholder="Price"
                        type="number"
                        name="price"
                        value={price || ''}
                        onChange={e => setPrice(parseFloat(e.target.value))}
                        min="0"
                        step="0.01"
                    />
                </label>
                <div className={styles.authors}>
                    <span>Authors</span>
                    {names.map((name, index) => (
                        <div key={index} className={styles.authorItem}>
                            <input
                                type="text"
                                value={name}
                                onChange={(e) => handleInputChange(index, e.target.value)}
                                placeholder="Name"
                                required={true}
                            />
                            <a onClick={() => setNames(names.filter(item => item !== name))}>-</a>
                        </div>
                    ))}
                    <input type='hidden' name="authorsName" value={JSON.stringify(names)} />
                    <a onClick={() => setNames([...names, ""])}>+</a>
                </div>
                <button type="submit" className={styles.saveBtn}>SAVE</button>
            </Form>
        </>
    );
}