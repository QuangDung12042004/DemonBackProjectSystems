import React, { useState } from 'react';

interface LoginProps {
    onLoginSuccess: () => void;
}

const Login: React.FC<LoginProps> = ({ onLoginSuccess }) => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleLogin = async (e: React.FormEvent) => {
        e.preventDefault();

        // Đổi cái Port 7061 này thành Port thật trên Swagger C# của em nhé!
        const apiUrl = 'https://localhost:7061/api/auth/login';

        try {
            const response = await fetch(apiUrl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ email, password })
            });

            const data = await response.json();

            if (data.success) {
                // Đăng nhập thành công! Cất cái thẻ JWT vào két sắt LocalStorage
                localStorage.setItem('animefit-jwt', data.token);

                // Báo cho App.tsx biết để mở cổng vào Dashboard
                onLoginSuccess();
            } else {
                // Sai pass hoặc email thì ném thông báo ra màn hình
                alert('❌ Đăng nhập thất bại: ' + data.message);
            }
        } catch (error) {
            console.error('Lỗi rồi đại vương ơi:', error);
            alert('Không thể kết nối đến Máy chủ Huấn Luyện!');
        }
    };

    return (
        <div style={{
            display: 'flex', flexDirection: 'column', justifyContent: 'center', alignItems: 'center',
            minHeight: '100vh', backgroundColor: '#0a0a0a', color: '#fff', padding: '20px',
            fontFamily: 'sans-serif'
        }}>
            <div style={{
                width: '100%', maxWidth: '350px', padding: '30px 20px',
                border: '1px solid #e50914', borderRadius: '12px',
                boxShadow: '0 0 20px rgba(229, 9, 20, 0.2)', backgroundColor: '#121212'
            }}>
                <h1 style={{ textAlign: 'center', color: '#e50914', marginBottom: '5px', fontSize: '24px', textTransform: 'uppercase', letterSpacing: '2px' }}>
                    AnimeFit Pro
                </h1>
                <p style={{ textAlign: 'center', color: '#888', marginBottom: '30px', fontSize: '13px' }}>
                    Đánh thức sức mạnh tiềm ẩn
                </p>

                <form onSubmit={handleLogin} style={{ display: 'flex', flexDirection: 'column', gap: '15px' }}>
                    <div>
                        <label style={{ display: 'block', marginBottom: '8px', fontSize: '13px', color: '#ccc' }}>Email chiến binh</label>
                        <input
                            type="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            placeholder="gund@animefit.com"
                            style={{
                                width: '100%', padding: '14px', borderRadius: '8px', border: '1px solid #333',
                                backgroundColor: '#1a1a1a', color: '#fff', outline: 'none', boxSizing: 'border-box', fontSize: '16px'
                            }}
                            required
                        />
                    </div>

                    <div>
                        <label style={{ display: 'block', marginBottom: '8px', fontSize: '13px', color: '#ccc' }}>Mã khóa (Password)</label>
                        <input
                            type="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            placeholder="••••••••"
                            style={{
                                width: '100%', padding: '14px', borderRadius: '8px', border: '1px solid #333',
                                backgroundColor: '#1a1a1a', color: '#fff', outline: 'none', boxSizing: 'border-box', fontSize: '16px'
                            }}
                            required
                        />
                    </div>

                    <button type="submit" style={{
                        marginTop: '15px', padding: '15px', borderRadius: '8px', border: 'none',
                        backgroundColor: '#e50914', color: '#fff', fontWeight: 'bold', fontSize: '16px',
                        cursor: 'pointer', textTransform: 'uppercase', letterSpacing: '1px',
                        boxShadow: '0 4px 15px rgba(229, 9, 20, 0.4)', transition: 'transform 0.1s'
                    }}>
                        Đăng Nhập Ngay
                    </button>
                </form>

                <div style={{ marginTop: '25px', textAlign: 'center', fontSize: '13px', color: '#888' }}>
                    Chưa có thẻ hội viên? <span style={{ color: '#e50914', cursor: 'pointer', fontWeight: 'bold' }}>Gia nhập</span>
                </div>
            </div>
        </div>
    );
};

export default Login;