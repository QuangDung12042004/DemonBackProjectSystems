# Tổng Quan Dự Án (Project Overview) - AnimeFit Pro

**AnimeFit Pro** là nền tảng theo dõi và lên lịch tập gym được thiết kế đặc biệt với nguồn cảm hứng từ phong cách Anime. Không chỉ là một ứng dụng fitness thông thường, AnimeFit Pro mang đến trải nghiệm "Gamification" (trò chơi hoá), giúp biến quá trình tập luyện gian khổ thành một hành trình "Thăng cấp" (Level Up) như các nhân vật chính trong Anime (Shounen Protagonist).

## 1. Tầm Nhìn & Mục Tiêu (Vision & Goals)

- **Mục tiêu cốt lõi**: Xây dựng một ứng dụng Fitness chuẩn doanh nghiệp (Enterprise-level), đầy đủ tính năng từ việc tạo lịch tập tự động (AI-driven), ghi chú buổi tập (Workout Tracking) đến theo dõi thay đổi cơ thể.
- **Trải nghiệm người dùng**: Giao diện mang đậm phong cách tương lai, Cyberpunk/Anime, sử dụng Dark Mode và Neon Accents.
- **Kiến trúc hệ thống**: Xây dựng theo mô hình Microservices/Modular Monolith, tách biệt hoàn toàn Frontend và Backend để dễ dàng scale-up và bảo trì. (0 -> Z Project).

## 2. Đối Tượng Khách Hàng (Target Audience)

1. **Wibu / Anime Fans**: Những người yêu thích văn hóa Anime (Dragon Ball, Baki, Attack on Titan, Solo Leveling...) và muốn có một động lực tập luyện sát với sở thích.
2. **Người mới tập Gym (Beginners)**: Cần một hệ thống tự động sinh ra lịch tập (Workout Plan) đơn giản, dễ hiểu, tránh cảm giác bối rối.
3. **Gymer đã có kinh nghiệm (Intermediate/Advanced)**: Cần một công cụ Tracking mạnh mẽ để ghi lại số Set, Rep, Volume mỗi buổi tập nhằm áp dụng Progressive Overload.

## 3. Lộ Trình Phát Triển (Roadmap)

### Giai đoạn 1: MVP (Minimum Viable Product)
Tập trung vào luồng (flow) chính của một app Fitness:
- Hệ thống User Auth (Đăng nhập, Đăng ký).
- Onboarding (Nhập chiều cao, cân nặng, mục tiêu và chọn phong cách "Anime Body" muốn hướng tới).
- Generator: Hệ thống tự động tạo lịch tập theo tuần dựa trên Goal.
- Tracking: Giao diện khi người dùng mang app ra phòng gym (Tick hoàn thành Set/Rep).
- Dashboard: Biểu đồ đơn giản theo dõi Volume và Cân nặng.

### Giai đoạn 2: Scale & Gamification (Dự kiến)
- **Hệ thống Thành tựu (Achievements)**: Mở khóa các huy hiệu Anime.
- **AI Integration**: Dùng Python/FastAPI tích hợp Machine Learning để phân tích quá trình tập và tự động điều chỉnh độ khó của lịch.
- **Mạng xã hội (Social/Guild)**: Tạo Clan/Bang hội để ganh đua kết quả.

## 4. Công Nghệ Sử Dụng (Tech Stack)

### Frontend (Client-Side)
- **Framework**: React.js / Next.js (App Router).
- **Ngôn ngữ**: TypeScript (Bắt buộc cho dự án lớn).
- **Styling**: Tailwind CSS (Kết hợp với các UI library như Shadcn/UI, Framer Motion để làm animation đẹp mắt).
- **State Management**: Zustand / Redux Toolkit.
- **Data Fetching**: React Query (TanStack Query) hoặc SWR.

### Backend (Server-Side)
- **Framework Core**: C# ASP.NET Core Web API (.NET 8). Lý do: Cực kỳ mạnh mẽ, xử lý concurrency tốt, kiến trúc enterprise chuẩn.
- **ORM**: Entity Framework Core.
- **Architecture**: Clean Architecture hoặc CQRS (với MediatR).
- **Authentication**: JWT (JSON Web Tokens).

### Database & Storage
- **Relational DB**: PostgreSQL hoặc SQL Server.
- **Storage**: AWS S3 hoặc Cloudinary (Để lưu ảnh Avatar, Progress Photos, Hình bài tập).

### AI / Data Science (Tách service riêng nếu cần)
- **Ngôn ngữ**: Python.
- **Framework API**: FastAPI.
- **Chức năng**: Thuật toán xếp lịch tập tối ưu (AI Generator).

### Deployment & DevOps
- **Frontend**: Vercel.
- **Backend**: Render / Railway / Azure App Services.
- **Database**: Supabase / Neon (PostgreSQL) hoặc Azure SQL.
- **CI/CD**: GitHub Actions.