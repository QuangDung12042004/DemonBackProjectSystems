import React from 'react';

const Navbar = () => {
    return (
        <nav style={{ background: '#1a1a1a', color: '#fff', padding: '15px 20px', display: 'flex', justifyContent: 'space-between' }}>
            <h2 style={{ margin: 0, color: '#e50914' }}>🔥 AnimeFit Pro</h2>
            <div>
                <span style={{ marginRight: '15px' }}>💪 Trạng thái API: Connect</span>
                <button style={{ padding: '5px 10px', cursor: 'pointer' }}>Đăng nhập</button>
            </div>
        </nav>
    );
};

export default Navbar;