import React from 'react';

const Sidebar = () => {
    return (
        <aside style={{ width: '250px', background: '#2c2c2c', color: '#fff', padding: '20px', height: '100vh' }}>
            <ul style={{ listStyleType: 'none', padding: 0, lineHeight: '2.5' }}>
                <li style={{ cursor: 'pointer' }}>🏠 Dashboard</li>
                <li style={{ cursor: 'pointer', color: '#e50914' }}>⚔️ Tạo Giáo Án (AI)</li>
                <li style={{ cursor: 'pointer' }}>📚 Thư Viện Bài Tập</li>
                <li style={{ cursor: 'pointer' }}>👤 Hồ Sơ Body</li>
            </ul>
        </aside>
    );
};

export default Sidebar;