import { useState, useEffect } from 'react';

// Hook này dùng Generic Type <T> của TypeScript để dùng được cho mọi loại dữ liệu (string, boolean, object...)
function useLocalStorage<T>(key: string, initialValue: T) {
    // Khởi tạo state bằng cách đọc từ localStorage trước (nếu có)
    const [storedValue, setStoredValue] = useState<T>(() => {
        try {
            const item = window.localStorage.getItem(key);
            return item ? JSON.parse(item) : initialValue;
        } catch (error) {
            console.error("Lỗi đọc localStorage:", error);
            return initialValue;
        }
    });

    // Mỗi khi state thay đổi, tự động lưu ngược lại xuống localStorage
    useEffect(() => {
        try {
            window.localStorage.setItem(key, JSON.stringify(storedValue));
        } catch (error) {
            console.error("Lỗi ghi localStorage:", error);
        }
    }, [key, storedValue]);

    return [storedValue, setStoredValue] as const;
}

export default useLocalStorage;